using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCache.Repositories
{
    public class IntDateTimeRepository : IRepository<int, DateTime>
    {
        public Dictionary<int, DateTime> Repository { get; } = new Dictionary<int, DateTime>()
        {
            [1] = new DateTime(2020, 1, 1),
            [2] = new DateTime(2021, 1, 1),
            [3] = new DateTime(2022, 1, 1),
        };

        public DateTime GetById(int id)
        {
            Thread.Sleep(1000);
            return Repository[id];
        }
    }
}
