using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsDataAggregator.BusinessLogic
{
    public class TicketsFormatter : ITicketsFormatter
    {
        const char Splitter = '|';
        const int TitleColumnWidth = -35;

        public string Format(IEnumerable<Ticket> tickets)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var ticket in tickets)
            {
                var formattedDate = ticket.Date.ToString("d", CultureInfo.InvariantCulture);
                var formattedTime = ticket.Time.ToString(@"hh\:mm", CultureInfo.InvariantCulture);

                sb.Append($"{ticket.Title,TitleColumnWidth}{Splitter} {formattedDate} {Splitter} {formattedTime}");
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
