using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTopics
{
    public class TablePrinter<T> : IPrinter<T>
    {
        private const char CellSplitter = '|';
        private const int ColumnWidth = 15;
        IUserInteraction _userInteraction;

        public TablePrinter(IUserInteraction userInteraction)
        {
            _userInteraction = userInteraction;
        }

        public void Print(IEnumerable<T> items)
        {
            Type type = typeof(T);
            var properties = type.GetProperties().Where(p => p.Name != "EqualityContract");
            string columnNames = string.Join("", properties.Select(p => $"{p.Name.PadRight(ColumnWidth)}{CellSplitter}"));

            StringBuilder sb = new();
            sb.AppendLine(columnNames);
            int totalWidth = properties.Count() * (ColumnWidth) + properties.Count();
            sb.AppendLine(new string('-', totalWidth));

            foreach (T item in items)
            {
                foreach(var prop in properties)
                {
                    var value = prop.GetValue(item) == null ? "" : prop.GetValue(item)!.ToString();
                    string itemInfo = value!.PadRight(ColumnWidth) + CellSplitter; 
                    sb.Append(itemInfo);
                } 
                sb.AppendLine();
            }
            _userInteraction.ShowMessage(sb.ToString());
        }
    }

    public interface IPrinter<T>
    {
        void Print(IEnumerable<T> items);
    }
}
