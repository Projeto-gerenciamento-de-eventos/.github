global using GerenciadorEventos.Dtos;
global using GerenciadorEventos.Models;
global using GerenciadorEventos.Services;
global using AutoMapper;
global using Microsoft.EntityFrameworkCore;
using GerenciadorEventos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services
    .AddControllers(option => { option.ReturnHttpNotAcceptable = true; })
    .AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ITipoUsuarioService, TipoUsuarioService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ICategoriaEventoService, CategoriaEventoService>();
builder.Services.AddScoped<IComentarioService, ComentarioService>();
builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<IInscricaoService, InscricaoService>();


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nome da Sua API");
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
