using Ecommerce_API.Hubs;
using Ecommerce_API.Model;
using Ecommerce_API.Services;
using Ecommerce_API.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<Context>();

builder.Services.AddIdentity<ApplcationUser, IdentityRole>()
    .AddEntityFrameworkStores<Context>()
    .AddDefaultTokenProviders()
    .AddSignInManager<SignInManager<ApplcationUser>>();



builder.Services.AddScoped<IShoppingCartRepo, ShoppingCartRepo>();
builder.Services.AddScoped<IShippingRepo, ShippingRepo>();
builder.Services.AddScoped<IProductesRepo, ProductesRepo>();
builder.Services.AddScoped<IPromotionsRepo, PromotionsRepo>();
builder.Services.AddScoped<IProductWithPormotionsRepo, ProductWithPormotionsRepo>();
builder.Services.AddScoped<IProductReviewRepo, ProductReviewRepo>();
builder.Services.AddScoped<IOrdersRepo, OrdersRepo>();
builder.Services.AddScoped<IOrderDeetailsRepo, OrderDeetailsRepo>();
builder.Services.AddScoped<ICategoriesRepo, CategoriesRepo>();











builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        // ValidIssuer =

        ValidateAudience = true,

        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"])),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        //LifetimeValidator=
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        ValidAudience = builder.Configuration["JWT:ValidAudiance"],
        ClockSkew = TimeSpan.Zero,


    };


});

builder.Services.AddSignalR();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapHub<ChatHub>("/Chat");

app.MapControllers();

app.Run();
