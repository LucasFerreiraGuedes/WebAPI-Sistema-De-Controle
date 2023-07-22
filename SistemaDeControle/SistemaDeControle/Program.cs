using SistemaDeControle.Context;
using SistemaDeControle.Repository.CargoRepo;
using SistemaDeControle.Repository.CategoriaRepo;
using SistemaDeControle.Repository.DepartamentoRepo;
using SistemaDeControle.Repository.FuncionarioRepo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<AppDbContext>(builder.Configuration.GetConnectionString("MinhaConexao"));

builder.Services.AddScoped<IDepartamento,DepartamentoRepository>();
builder.Services.AddScoped<ICargoRepository,CargoRepository>();
builder.Services.AddScoped<ICategoriaRepository,CategoriaRepository>();
builder.Services.AddScoped<IFuncionarioRepository,FuncionarioRepository>();

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
