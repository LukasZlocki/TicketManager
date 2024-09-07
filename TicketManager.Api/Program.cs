using Microsoft.EntityFrameworkCore;
using TicketManager.Infrastructure.Persistance;
using TicketManager.Infrastructure.Seeders;
using TicketManager.Services.Department_Services;
using TicketManager.Services.FactoryLocation_Services;
using TicketManager.Services.LabLocation_Services;
using TicketManager.Services.LabLocationServices;
using TicketManager.Services.Product_Services;
using TicketManager.Services.ProductDisplacement_Services;
using TicketManager.Services.ProductFamily_Services;
using TicketManager.Services.ProductServices;
using TicketManager.Services.ProductType_Services;
using TicketManager.Services.ProductTypeServices;
using TicketManager.Services.ReportType_Services;
using TicketManager.Services.ReportTypeServices;
using TicketManager.Services.Test_services;
using TicketManager.Services.Test_Services;
using TicketManager.Services.TestParameter_Services;
using TicketManager.Services.TicketTest_Services;
using TicketManager.Services.Ticket_Services;
using TicketManager.Services.TicketTestParameter_Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.DataProtection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

// Register DbContext
builder.Services.AddDbContext<TicketManagerDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("TicketManagerConnectionString")));

// Add authorization
var secret = builder.Configuration.GetValue<string>("Jwt:Secret"); 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "doseHieu",
        ValidAudience = "doseHieu",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
    };
});

builder.Services.AddAuthorization();

// Active identity APIs (both cookies and tokens)
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<TicketManagerDbContext>();

// Register seeder
builder.Services.AddScoped<DbSeeder>();

// Register controller services
builder.Services.AddTransient<ILabLocationService, LabLocationService>();
builder.Services.AddTransient<IFactoryLocationService, FactoryLocationService>();
builder.Services.AddTransient<IDepartmentService, DepartmentService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductFamilyService, ProductFamilyService>();
builder.Services.AddTransient<IProductDisplacementService, ProductDisplacementService>();
builder.Services.AddTransient<IProductTypeService, ProductTypeService>();
builder.Services.AddTransient<IReportTypeService, ReportTypeService>();
builder.Services.AddTransient<ITicketTestService, TicketTestService>();
builder.Services.AddTransient<ITestService, TestService>();
builder.Services.AddTransient<ITestParameterServices, TestParameterServices>();
builder.Services.AddTransient<ITicketService, TicketService>();
builder.Services.AddTransient<ITicketTestParameterService, TicketTestParameterService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Seeding
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<DbSeeder>();
await seeder.Seed();

// Map identity API
app.MapIdentityApi<IdentityUser>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
