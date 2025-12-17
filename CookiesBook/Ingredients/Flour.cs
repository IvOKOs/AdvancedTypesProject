using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesBook.Ingredients
{
    public abstract class Flour : Ingredient
    {
        public override string Preparation => "Sieve. Add to other ingredients.";
    }
}
