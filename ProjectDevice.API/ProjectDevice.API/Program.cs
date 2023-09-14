using AutoMapper;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Microsoft.OData.ModelBuilder;
using ProjectDevice.API.Context;
using ProjectDevice.API.Middlewares;
using ProjectDevice.API.Models;
using ProjectDevice.API.Repository.Classes;
using ProjectDevice.API.Repository.Interfaces;
using server.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//configure database
string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection")!;
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

//services
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();


//AutoMapper
IMapper mapper = MapperConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Configuring Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configuring OData
ODataModelBuilder modelBuilder = new ODataModelBuilder();
modelBuilder.EntitySet<Device>("Devices")
    .EntityType.HasKey(d => d.DeviceId);
modelBuilder.EntitySet<Subscription>("Subscriptions")
    .EntityType.HasKey(s => s.SubscriptionId);

builder.Services.AddControllers().AddOData(opt => opt.EnableQueryFeatures(null)
.AddRouteComponents(model: modelBuilder.GetEdmModel()));


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Static")),
    RequestPath = new PathString("/Static")
});

app.UseMiddleware(typeof(GlobalErrorHandlerMiddleware));

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(x =>
x.AllowAnyHeader()
.AllowAnyOrigin()
.AllowAnyMethod()
);
app.MapControllers();

app.Run();
