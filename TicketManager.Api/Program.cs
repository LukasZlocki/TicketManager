using Microsoft.AspNetCore.Authentication.Negotiate;
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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
    });
});

// Add aouthorization
builder.Services.AddAuthorization();

// Register DbContext
builder.Services.AddDbContext<TicketManagerDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("TicketManagerConnectionString")));

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

// Map identity API
app.MapIdentityApi<IdentityUser>();

//app.MapGroup("/identity").MapIdentityApi<IdentityUser>();

// Seeding
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<DbSeeder>();
await seeder.Seed();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
