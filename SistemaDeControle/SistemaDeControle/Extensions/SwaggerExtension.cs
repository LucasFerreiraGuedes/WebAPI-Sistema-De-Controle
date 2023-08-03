using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Reflection;

namespace SistemaDeControle.Extensions
{
	public static class SwaggerExtension
	{
        public static void ConfigureSwagger(this IServiceCollection services)
		{
			services.AddVersionedApiExplorer(options =>

			{
				options.GroupNameFormat = "'v'VVV";
				options.SubstituteApiVersionInUrl = true;
			}
		   )
		   .AddApiVersioning(options =>

		   {
			   options.DefaultApiVersion = new ApiVersion(1, 0);
			   options.AssumeDefaultVersionWhenUnspecified = true;
			   options.ReportApiVersions = true;
		   }
		   );

			var apiProviderDescription = services.BuildServiceProvider()
												 .GetService<IApiVersionDescriptionProvider>();


			services.AddSwaggerGen(options =>
			{
				foreach (var description in apiProviderDescription.ApiVersionDescriptions)
				{
					options.SwaggerDoc(
						description.GroupName,
						new Microsoft.OpenApi.Models.OpenApiInfo()
						{
							Title = "Sistema de Controle API",
							Version = description.ApiVersion.ToString(),
							TermsOfService = new Uri("http://SeusTermosDeUso.com"),
							Description = "WebAPI de um Sistema de Controle de Funcionários",
							License = new Microsoft.OpenApi.Models.OpenApiLicense
							{
								Name = "Sistema de Controle License",
								Url = new Uri("http://mit.com")
							},
							Contact = new Microsoft.OpenApi.Models.OpenApiContact
							{
								Name = "Lucas Ferreira Guedes",
								Email = "lucasferreiraguedes00@gmail.com",
								Url = new Uri("http://programadamente.com")
							}

						}
					);
				}
				var xmlComments = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlFullComment = Path.Combine(AppContext.BaseDirectory, xmlComments);

				options.IncludeXmlComments(xmlFullComment);

			});


		}
	}
}
