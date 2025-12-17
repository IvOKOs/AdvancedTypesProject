using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCache.Repositories
{
    public class StringsRepository : IRepository<string, string>
    {
        public Dictionary<string, string> Repository { get; } = new Dictionary<string, string>()
        {
            ["id1"] = "Some data for id1",
            ["id2"] = "Some data for id2",
            ["id3"] = "Some data for id3",
        };

        public string GetById(string id)
        {
            Thread.Sleep(1000);
            return Repository[id];
        }
    }
}
