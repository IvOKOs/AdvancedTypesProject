using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTopics
{
    public class ConsoleUserInteraction : IUserInteraction
    {
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public string? SelectOption()
        {
            return Console.ReadLine();
        }
    }

    public interface IUserInteraction
    {
        void ShowMessage(string message);
        string? SelectOption();
    }
}
