using System.ServiceModel;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);


//配置可以同步请求读取流数据
builder.Services.Configure<KestrelServerOptions>(
                    x => x.AllowSynchronousIO = true)
                .Configure<IISServerOptions>(
                    x => x.AllowSynchronousIO = true);

// Add services to the container.
builder.Services.AddSingleton<CalculatorService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseSOAPEndpoint<CalculatorService>("/CalculatorService.svc", new BasicHttpBinding());

app.UseAuthorization();

app.MapControllers();

app.Run();
