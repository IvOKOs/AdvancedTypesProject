using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesBook.Ingredients
{
    public class CocoaPowder : Ingredient
    {
        public override int Id => 8;

        public override string Name => "Cocoa powder";

        public override string Preparation => "Add to other ingredients.";
    }
}
