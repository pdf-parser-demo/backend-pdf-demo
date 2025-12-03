using System;

namespace backend_pdf_demo.Models;

public class OcrResponse
{

	public string? Text { get; set; }
	public string? Language { get; set; }
	public float Confidence { get; set; }

}
