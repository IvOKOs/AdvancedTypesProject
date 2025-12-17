using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesBook.Ingredients
{
    public class Chocolate : Ingredient
    {
        public override int Id => 4;

        public override string Name => "Chocolate";

        public override string Preparation => "Melt in a water bath. Add to other ingredients.";
    }
}
