 using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IronPdf;

namespace B1Site
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            //var htmltoPDF = new HtmlToPdf();
            //var pdfDocument = HtmlToPdf.RenderHTMLFileAsPdf("CustomerStatement.cshtml");
            //PdfDocument.SaveAs("Invoice.pdf");
            /**
            PDF from HTML String
            anchor-create-a-pdf-with-an-html-string-in-net-c
            **/
            // Render any HTML fragment or document to HTML
            var Renderer = new IronPdf.ChromePdfRenderer();
            var PDF = Renderer.RenderHtmlAsPdf("<h1>Hello IronPdf</h1>");
            var OutputPath = "pixel-perfect.pdf";
            PDF.SaveAs(OutputPath);

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
