using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using TicketManager.Infrastructure.Persistance;
using TicketManager.Infrastructure.Seeders;
using TicketManager.Services.Department_Services;
using TicketManager.Services.FactoryLocation_Services;
using TicketManager.Services.LabLocation_Services;
using TicketManager.Services.Product_Services;
using TicketManager.Services.ProductDisplacement_Services;
using TicketManager.Services.ProductType_Services;
using TicketManager.Services.ReportType_Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

// Register seeder
builder.Services.AddScoped<DbSeeder>();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

// Register DbContext
builder.Services.AddDbContext<TicketManagerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TicketManagerConnectionString")));

builder.Services.AddTransient<ILabLocationService, LabLocationService>();
builder.Services.AddTransient<IFactoryLocationService, FactoryLocationService>();
builder.Services.AddTransient<IDepartmentService, DepartmentService>();
builder.Services.AddTransient<IProductDisplacementService, ProductDisplacementService>();
builder.Services.AddTransient<IProductTypeService, ProductTypeService>();
builder.Services.AddTransient<IReportTypeService, ReportTypeService>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
