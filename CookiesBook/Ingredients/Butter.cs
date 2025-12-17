using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesBook.Ingredients
{
    public class Butter : Ingredient
    {
        public override int Id => 3;

        public override string Name => "Butter";

        public override string Preparation => "Melt on low heat. Add to other ingredients.";
    }
}
