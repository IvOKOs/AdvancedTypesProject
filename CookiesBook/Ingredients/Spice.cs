using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesBook.Ingredients
{
    public abstract class Spice : Ingredient
    {
        public override string Preparation => "Take half a teaspoon. Add to other ingredients.";
    }
}
