using Microsoft.AspNetCore.Mvc.ApiExplorer;
using SistemaDeControle.Context;
using SistemaDeControle.Extensions;
using SistemaDeControle.Repository.CargoRepo;
using SistemaDeControle.Repository.CategoriaRepo;
using SistemaDeControle.Repository.DepartamentoRepo;
using SistemaDeControle.Repository.FuncionarioRepo;
using SistemaDeControle.Repository.GestorRepo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();
builder.Services.AddSqlServer<AppDbContext>(builder.Configuration.GetConnectionString("MinhaConexao"));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IDepartamento,DepartamentoRepository>();
builder.Services.AddScoped<ICargoRepository,CargoRepository>();
builder.Services.AddScoped<ICategoriaRepository,CategoriaRepository>();
builder.Services.AddScoped<IFuncionarioRepository,FuncionarioRepository>();
builder.Services.AddScoped<IGestorRepository, GestorRepository>();

var apiProviderDescription = builder.Services.BuildServiceProvider()
												 .GetService<IApiVersionDescriptionProvider>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(options =>
	{
		foreach (var description in apiProviderDescription.ApiVersionDescriptions)
		{
			options.RoutePrefix = "swagger";
			options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
								   description.GroupName.ToUpperInvariant());
		}
		

	}
	);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
