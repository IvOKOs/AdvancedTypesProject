using CookiesBook;
using CookiesBook.Ingredients;
using CookiesBook.Recipes;
using System.Net.Http.Headers;
using System.Text.Json;

ITextRepository textRepository = Settings.Format == FileFormat.Json ? new JsonRepository() : new TextRepository();

CookiesApp app = new CookiesApp(new UIInteraction(new IngredientsContainer()), new RecipeRepository(textRepository, new IngredientsContainer()));
app.Run();


public class CookiesApp
{
    private readonly IUIInteraction _uiInteraction;
    private readonly IRecipeRepository _recipeRepository;

    public CookiesApp(IUIInteraction uiInteraction, IRecipeRepository recipeRepository)
    {
        _uiInteraction = uiInteraction;
        _recipeRepository = recipeRepository;
    }

    public void Run()
    {
        string filePath = Settings.ToFilePath();
        var existingRecipes = _recipeRepository.LoadRecipes(filePath);
        _uiInteraction.PrintExistingRecipes(existingRecipes);
        _uiInteraction.PrintIngredients();
        var ingredients = _uiInteraction.SelectIngredientsForRecipe();
        if(ingredients.Count() > 0)
        {
            Recipe recipe = new (ingredients);
            existingRecipes.Add(recipe);
            _recipeRepository.SaveRecipe(filePath, existingRecipes);
            _uiInteraction.ShowMessage("Recipe added:");
            _uiInteraction.PrintRecipe(recipe);
        }
        else
        {
            _uiInteraction.ShowMessage("No ingredients have been selected. Recipe will not be saved.");
        }
        _uiInteraction.Exit();
    }
}

public class IngredientsContainer
{
    public IEnumerable<Ingredient> AllIngredients { get; } = new List<Ingredient>()
    {
        new WheatFlour(),
        new CoconutFlour(),
        new Butter(),
        new Chocolate(),
        new Sugar(),
        new Cardamom(),
        new Cinnamon(),
        new CocoaPowder(),
    };
}

public interface ITextRepository
{
    List<string> ReadFromFile(string filePath);
    void WriteToFile(string filePath, List<string> strings);
}


public interface IRecipeRepository
{
    List<Recipe> LoadRecipes(string filePath);
    void SaveRecipe(string filePath, List<Recipe> recipes);
}

class TextRepository : ITextRepository
{
    public static readonly string Separator = Environment.NewLine;
    public List<string> ReadFromFile(string filePath)
    {
        var fileContents = File.ReadAllText(filePath);
        return fileContents.Split(Separator).ToList();
    }

    public void WriteToFile(string filePath, List<string> strings) =>
        File.WriteAllText(filePath, string.Join(Separator, strings));
}

class JsonRepository : ITextRepository
{
    public List<string> ReadFromFile(string filePath)
    {
        var fileContents = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<string>>(fileContents);
    }

    public void WriteToFile(string filePath, List<string> strings) =>
        File.WriteAllText(filePath, JsonSerializer.Serialize(strings));
}

public class RecipeRepository : IRecipeRepository
{
    ITextRepository _textRepository;
    IngredientsContainer _ingredientsContainer;

    public RecipeRepository(ITextRepository textRepository, IngredientsContainer ingredientsContainer)
    {
        _textRepository = textRepository;
        _ingredientsContainer = ingredientsContainer;
    }

    public List<Recipe> LoadRecipes(string filePath)
    {
        if (!File.Exists(filePath)) return new List<Recipe>();
        List<Recipe> recipes = new();
        List<string> recipesAsString = _textRepository.ReadFromFile(filePath);
        foreach(var recipeAsString in recipesAsString)
        {
            string[] ids = recipeAsString.Split(',');
            List<Ingredient> ingredients = new();
            foreach(var id in ids)
            {
                var ingredient = _ingredientsContainer.AllIngredients.Where(i => i.Id == int.Parse(id)).FirstOrDefault();
                ingredients.Add(ingredient);
            }
            Recipe recipe = new(ingredients);
            recipes.Add(recipe);
        }
        return recipes;
    }

    public void SaveRecipe(string filePath, List<Recipe> recipes)
    {
        List<string> idsRows = new();
        foreach (var recipe in recipes)
        {
            List<int> ids = new List<int>();
            string content = "";
            foreach (var ingredient in recipe.Ingredients)
            {
                ids.Add(ingredient.Id);
            }
            content = string.Join(',', ids);
            idsRows.Add(content);
        }
        _textRepository.WriteToFile(filePath, idsRows);
    }
}

public interface IUIInteraction
{
    void PrintExistingRecipes(IEnumerable<Recipe> recipes);
    void PrintRecipe(Recipe recipe);
    void PrintIngredients();
    IEnumerable<Ingredient> SelectIngredientsForRecipe();
    void ShowMessage(string message);
    void Exit();
}

public class UIInteraction : IUIInteraction
{
    private readonly IngredientsContainer _ingredientsContainer;

    public UIInteraction(IngredientsContainer ingredientsContainer)
    {
        _ingredientsContainer = ingredientsContainer;
    }

    public void PrintIngredients()
    {
        IEnumerable<Ingredient> allIngredients = _ingredientsContainer.AllIngredients;
        int orderNum = 1;
        foreach (var ingredient in allIngredients)
        {
            Console.WriteLine($"{orderNum}. {ingredient.Name}");
            orderNum++;
        }
    }

    public IEnumerable<Ingredient> SelectIngredientsForRecipe()
    {
        List<Ingredient> ingredients = new();
        while (true)
        {
            ShowMessage("Add an ingredient by its ID or type anything else if finished.");
            string userInput = Console.ReadLine();
            if(int.TryParse(userInput, out int id))
            {
                var ingredient = _ingredientsContainer.AllIngredients.Where(i => i.Id == id).FirstOrDefault();
                if (ingredient is not null)
                {
                    ingredients.Add(ingredient);
                }
            }
            else
            {
                return ingredients;
            }
        }
    }

    public void PrintExistingRecipes(IEnumerable<Recipe> recipes)
    {
        Console.WriteLine("Existing recipes are:" + "\n");
        int orderNum = 1;
        //for(int i = 0; i  < recipes.Count(); i++)
        foreach (var recipe in recipes)
        {
            Console.WriteLine($"***** {orderNum} *****");
            Console.WriteLine(recipe);
            Console.WriteLine(Environment.NewLine);
            orderNum++;
        }
    }

    public void PrintRecipe(Recipe recipe)
    {
        Console.WriteLine(recipe);
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void Exit()
    {
        Console.ReadKey();
    }
}
