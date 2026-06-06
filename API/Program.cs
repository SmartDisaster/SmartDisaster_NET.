using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SmartDisaster.Application.Interfaces;
using SmartDisaster.Application.Services;
using SmartDisaster.Infrastructure.Data;
using SmartDisaster.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new()
    {
        Title = "SmartDisaster Portal API",
        Version = "v1",
        Description = "API para gestão de emergências e desastres — abrigos, necessidades, voluntários e doações.",
        Contact = new() { Name = "SmartDisaster Team" }
    });

    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
        options.IncludeXmlComments(xmlPath);
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Data Source=smartdisaster.db";

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));

// Repositories
builder.Services.AddScoped<IAbrigoRepository, AbrigoRepository>();
builder.Services.AddScoped<INecessidadeRepository, NecessidadeRepository>();
builder.Services.AddScoped<IVoluntarioRepository, VoluntarioRepository>();
builder.Services.AddScoped<IDoacaoRepository, DoacaoRepository>();

// Services
builder.Services.AddScoped<IAbrigoService, AbrigoService>();
builder.Services.AddScoped<INecessidadeService, NecessidadeService>();
builder.Services.AddScoped<IVoluntarioService, VoluntarioService>();
builder.Services.AddScoped<IDoacaoService, DoacaoService>();

var app = builder.Build();

// Aplicar migrations e seed na inicialização
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
    await SeedData.InitializeAsync(db);
}

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/json";

        var error = context.Features.Get<IExceptionHandlerFeature>();
        if (error is not null)
        {
            await context.Response.WriteAsJsonAsync(new
            {
                status = 500,
                title = "Erro interno do servidor.",
                detail = error.Error.Message
            });
        }
    });
});

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartDisaster Portal API v1");
    options.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
