using System;
using Microsoft.Extensions.Options;

using backend_pdf_demo.Models;

namespace backend_pdf_demo.Services;

public class FileService
{

	private readonly string _tempPath;

	public FileService(PathsOptions options)
	{

		_tempPath = options.TempFiles;

        if (!Directory.Exists(_tempPath))
			Directory.CreateDirectory(_tempPath);
	}

	public async Task<string> SaveFileAsync(IFormFile file)
	{
		var fullPath = Path.Combine(_tempPath, file.FileName);

		using var stream = File.Create(fullPath);
		await file.CopyToAsync(stream);

		return fullPath;
	}
}