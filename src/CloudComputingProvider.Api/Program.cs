using CloudComputingProvider.Api.Contracts;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.UseHttpsRedirection();

var availableServices = new List<Service>
{
    new()
    {
        Id = new("6cb82bcb-0f88-4708-bf3b-b926aa4d7027"),
        Name = "Microsoft Windows 11 Pro"
    },
    new()
    {
        Id = new("68de659d-f06e-4cfb-87d8-59b51640cc3e"),
        Name = "Microsoft Windows 11N"
    },
    new()
    {
        Id = new("fb0e510f-a83d-4cea-82cd-5b605751e034"),
        Name = "Atlassian Cloud License"
    },
    new()
    {
        Id = new("1a5b4c0d-93e4-417c-8298-b11704bb8c5d"),
        Name = "Atlassian License"
    },
    new()
    {
        Id = new("a83c0c96-d183-4ab3-a65d-47e9e8df8001"),
        Name = "Microsoft Visual Studio 2022 Professional"
    },
    new()
    {
        Id = new("85a897bb-885f-4ccc-9a0a-9b5ebfce29c2"),
        Name = "Microsoft Visual Studio 2022 Enterprise"
    },
    new()
    {
        Id = new("2922c820-e662-47da-8620-64c51a6bbc35"),
        Name = "Microsoft 365 Cloud"
    },
    new()
    {
        Id = new("4f309c8f-54bc-49ae-bf15-d2c493b64c77"),
        Name = "Autocad"
    },
    new()
    {
        Id = new("b3ee6aa1-e9cb-489c-aa99-df6a04926845"),
        Name = "Adobe Cloud Suite Windows"
    },
    new()
    {
        Id = new("85b1ef86-8a71-4fd5-8256-1290d4e4f81f"),
        Name = "Adobe Cloud Suite Mac"
    }
};

app.MapGet("/services", () =>
{
    var response = new CCPGetAllServicesResponse
    {
        Services = availableServices.ToArray()
    };
    return response;
})
.WithName("GetAllServices")
.WithOpenApi();

app.MapPost("/services/placeorder", (CCPPlaceOrderRequest request) =>
    {
        if (availableServices.Any(x => x.Id == request.ServiceId))
        {
            return Results.Created();
        }
        return Results.BadRequest("ServiceId not valid");
    })
.WithName("PlaceOrder")
.WithOpenApi();

app.Run();