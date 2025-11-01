using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.IoC;
using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Domain.EventHandlers;
using MicroRabbit.Transfer.Domain.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var configuration = builder.Configuration;
builder.Services.AddDbContext<TransferDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("TransferDbContext"));
}
);

builder.Services.AddSwaggerGen(c =>
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Transfer Microservice ",
        Version = "v1"
    })
);

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

registerServices(builder.Services);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
void registerServices(IServiceCollection services)
{
    DependencyContainer.RegisterServices(services);
}

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Transfer Mcroservice V1");
    });
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
configureEventBus(app);
void configureEventBus(WebApplication app)
{
    var eventbus = app.Services.GetRequiredService<IEventBus>();
    eventbus.Subscribe<TranferCreatedEvent, TransferEventHandler>();
}
app.Run();
