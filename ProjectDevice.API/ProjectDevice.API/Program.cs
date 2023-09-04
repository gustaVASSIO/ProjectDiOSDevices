using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using ProjectDevice.API.Context;
using ProjectDevice.API.Middlewares;
using ProjectDevice.API.Repository;
using server.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//configure database
string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection")!;
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

//services
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();


//AutoMapper
IMapper mapper = MapperConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles(new StaticFileOptions(){
    
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
