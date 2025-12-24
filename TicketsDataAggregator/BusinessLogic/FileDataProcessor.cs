using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace TicketsDataAggregator.BusinessLogic
{
    public class FileDataProcessor : IFileDataProcessor
    {
        public void Save(string data, string filePath)
        {
            File.WriteAllText(filePath, data);
        }
    }
}
