using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Adiciona o servico de controller 
builder.Services.AddControllers();

//Adicione o gerador do swagger � cole��o de servi�os
builder.Services.AddSwaggerGen(options =>
{
    //adiciona informa��es sobre a API no Swagger
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API inlock",
        Description = "API para gerenciamento de jogos",
        TermsOfService = new Uri("https://github.com/GabrielVictor0"),
        Contact = new OpenApiContact
        {
            Name = "Senai Inform�tica",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    // Configura  o swagger para usar o arquivo xml gerado
    //var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

//Comeca a config do swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

//Finaliza a config do swagger 


//Adiona o mapeamento da controller 
app.MapControllers();

app.UseHttpsRedirection();

app.Run();
