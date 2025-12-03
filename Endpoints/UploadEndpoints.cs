using System;
using backend_pdf_demo.Models;
using backend_pdf_demo.Services;

namespace backend_pdf_demo.Endpoints;

public static class UploadEndpoints
{
	public static void MapUploadEndpoints(this IEndpointRouteBuilder app)
	{
		app.MapPost("/upload", async (HttpRequest request, FileService fileService, OcrService ocrService) =>
		{
			if (!request.HasFormContentType)
				return Results.BadRequest("Se requiere form-data.");

			var form = await request.ReadFormAsync();
			var file = form.Files.GetFile("file");

			if (file is null)
				return Results.BadRequest("No se envió ningún archivo.");

			//Guarda archivo
			var savedFile = await fileService.SaveFileAsync(file);

			//Llamar al OCR
			var ocr = await ocrService.ProcessFileAsync(savedFile);

			return Results.Ok(new UploadResult
			{
				Message = "Archivo recibido.",
				SavedFile = savedFile
			});
		});
	}
}
