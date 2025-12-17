using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCache.Repositories
{
    public interface IRepository<T, U>
    {
        Dictionary<T, U> Repository { get; }
        U GetById(T id);
    }
}
