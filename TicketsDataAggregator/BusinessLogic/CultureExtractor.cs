using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TicketsDataAggregator.BusinessLogic
{
    public class CultureExtractor : ICultureExtractor
    {
        readonly Dictionary<string, string> _domainToCultureMapping = new Dictionary<string, string>()
        {
            ["com"] = "en-US",
            ["fr"] = "fr-FR",
            ["jp"] = "ja-JP",
        };

        public IFormatProvider GetCultureFromDomain(string text)
        {
            string? culture = null;
            try
            {
                string? domain = ExtractDomain(text);
                if (domain is null) throw new ArgumentException($"Domain of website is not found.");
                culture = _domainToCultureMapping.GetValueOrDefault(domain);
                if (culture is null) throw new ArgumentException("Culture is not found");
            }
            catch (ArgumentException)
            {
                // maybe do something specific and throw new and attach ex obj
                throw;
            }
            return new CultureInfo(culture);
        }

        private string? ExtractDomain(string text)
        {
            var match = Regex.Match(text, @"www\.ourCinema\.(\w+)", RegexOptions.IgnoreCase);

            return match.Success ? match.Groups[1].Value : null;
        }
    }
}
