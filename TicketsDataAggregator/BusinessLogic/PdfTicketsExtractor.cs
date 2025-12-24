using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UglyToad.PdfPig;
using UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor;

namespace TicketsDataAggregator.BusinessLogic
{
    public class PdfTicketsExtractor : IPdfDataExtractor
    {
        private readonly ITextToTicketsConverter _textToTicketsConverter;

        public PdfTicketsExtractor(ITextToTicketsConverter textToTicketsConverter)
        {
            _textToTicketsConverter = textToTicketsConverter;
        }

        public IEnumerable<Ticket> Extract(string path)
        {
            var files = Directory.EnumerateFiles(path, "*pdf", SearchOption.TopDirectoryOnly);

            List<Ticket> tickets = new List<Ticket>();
            foreach (var file in files)
            {
                if (file is null) throw new ArgumentException(nameof(file));
                using (PdfDocument document = PdfDocument.Open(file))
                {
                    foreach (var page in document.GetPages())
                    {
                        string text = ContentOrderTextExtractor.GetText(page);
                        var ticketsParsed = _textToTicketsConverter.Convert(text);
                        tickets.AddRange(ticketsParsed);
                    }
                }
            }
            return tickets;
        }
    }
}
