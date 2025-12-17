using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesBook.Ingredients
{
    public class Sugar : Ingredient
    {
        public override int Id => 5;

        public override string Name => "Sugar";

        public override string Preparation => "Add to other ingredients.";
    }
}
