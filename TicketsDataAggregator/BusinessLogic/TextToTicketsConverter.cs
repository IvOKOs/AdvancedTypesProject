using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor;

namespace TicketsDataAggregator.BusinessLogic
{
    public class TextToTicketsConverter : ITextToTicketsConverter
    {
        private readonly ICultureExtractor _cultureExtractor;

        public TextToTicketsConverter(ICultureExtractor cultureExtractor)
        {
            _cultureExtractor = cultureExtractor;
        }

        public IEnumerable<Ticket> Convert(string text)
        {
            var pattern =
@"Title:\s*(?<title>.+?)\s*
  Date:\s*(?<date>(\d{1,2}/\d{1,2}/\d{4})|(\d{4}/\d{2}/\d{2}))\s*
  Time:\s*(?<time>(\d{1,2}:\d{2}\s*(AM|PM))|(\d{2}:\d{2}))";

            var matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);

            var culture = _cultureExtractor.GetCultureFromDomain(text);

            var ticketsParsed = matches.Select(m => new Ticket
            {
                Title = m.Groups["title"].Value.Trim(),
                Date = DateTime.Parse(m.Groups["date"].Value, culture),
                Time = DateTime.Parse(m.Groups["time"].Value, culture).TimeOfDay
            }).ToList();

            return ticketsParsed;
        }
    }
}
