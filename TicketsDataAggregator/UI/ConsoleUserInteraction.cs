
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsDataAggregator.UI
{
    public class ConsoleUserInteraction : IConsoleUserInteraction
    {
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
