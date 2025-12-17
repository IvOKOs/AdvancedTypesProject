using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesBook.Ingredients
{
    public abstract class Ingredient
    {
        public abstract int Id { get; }
        public abstract string Name { get; }
        public abstract string Preparation { get; }

        public override string ToString()
        {
            return $"{Name}. {Preparation}";
        }
    }
}
