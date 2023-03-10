using AutoMapper;
using BookCRUD.Data.IConnection;
using BookCRUD.Service.Mapping;
using BookCRUD.Service.Services;
using BookCRUD.WebAPI.Connection.Concrete;
using BookCrudApp.IServices;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapProfile());

            });
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddSingleton<IBookService, BookService>();

builder.Services.AddSingleton<IConnectionFactory, ConnectionFactory>();



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
