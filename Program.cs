using backend_pdf_demo.Services;
using backend_pdf_demo.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy
                .WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .WithExposedHeaders("*");
        });
});

var tempRelative = builder.Configuration.GetValue<string>("Paths:TempFiles");
var projectRoot = builder.Environment.ContentRootPath;

var tempPath = Path.IsPathRooted(tempRelative)
    ? tempRelative
    : Path.Combine(projectRoot, tempRelative);

builder.Services.AddSingleton(new PathsOptions
{
    TempFiles = tempPath
});

builder.Services.AddHttpClient<OcrService>();
builder.Services.AddSingleton<FileService>();
builder.Services.AddScoped<OcrService>();

var app = builder.Build();
app.UseCors("AllowAngular");

app.MapGet("/", () => "Hello World!");

app.MapUploadEndpoints();

app.Run();
