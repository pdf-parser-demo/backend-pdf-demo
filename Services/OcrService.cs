using System;
using backend_pdf_demo.Models;

namespace backend_pdf_demo.Services;

public class OcrService
{
    private readonly HttpClient _http;

    public OcrService(HttpClient http)
    {
        _http = http; 
    }

    public async Task<OcrResponse> ProcessFileAsync(string filePath)
    {
        //TODO: cuando exista el microservicio
        return new OcrResponse
        {
            Text = "OCR pendiente",
            Language = "unknown",
            Confidence = 0
        };
    }
}
