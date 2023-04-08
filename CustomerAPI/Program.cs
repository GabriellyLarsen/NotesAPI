using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NotesAPI.Repositories;
using NotesAPI.Services;
using NotesAPI.Services.Mappers;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); }); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DbConfig
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SeverConnection")));

//Dependency Injection
builder.Services.AddScoped<IServiceProviderHandler, ServiceProviderHandler>();
builder.Services.AddScoped<ICreateNoteRequestMapper, CreateNoteRequestMapper>();
builder.Services.AddScoped<IGetNoteResponseMapper, GetNoteResponseMapper>();
builder.Services.AddScoped<ICreateNoteResponseMapper, CreateNoteResponseMapper>();
builder.Services.AddScoped<IUpdateNoteRequestMapper, UpdateNoteRequestMapper>();
builder.Services.AddScoped<IUpdateNoteResponseMapper, UpdateNoteResponseMapper>();
builder.Services.AddScoped<INoteService, NoteService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
