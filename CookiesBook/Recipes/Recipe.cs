using CookiesBook.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesBook.Recipes
{
    public class Recipe
    {
        public IEnumerable<Ingredient> Ingredients { get; }

        public Recipe(IEnumerable<Ingredient> ingredients)
        {
            Ingredients = ingredients;
        }

        public override string ToString()
        {
            List<string> ingredients = new();
            foreach (var ingredient in Ingredients)
            {
                ingredients.Add($"{ingredient.Name}. {ingredient.Preparation}");
            }
            return string.Join(Environment.NewLine, ingredients);
        }
    }
}
