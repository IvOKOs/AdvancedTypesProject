using Cookies;
using System.IO;
using System.Text;
using System.Text.Json;

List<Ingredient> ingredients = new List<Ingredient>()
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
List<List<Ingredient>> existingRecipes = new List<List<Ingredient>>();
List<Ingredient> recipe = new List<Ingredient>();

string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
string[] files = Directory.GetFiles(path).Where(f => Path.GetFileNameWithoutExtension(f) == Settings.FileName).ToArray();
string file = files.FirstOrDefault() ?? "";
if (!string.IsNullOrWhiteSpace(file))
{
    LoadRecipes(file, ingredients);
}
Console.WriteLine("Create a new cookie recipe! Available ingredients are:");
PrintIngredients(ingredients);
SelectIngredients();
if (IsRecipeValid())
{
    SaveRecipe();
}
Console.WriteLine("Press any key to exit.");
Console.ReadKey();





void PrintIngredients(List<Ingredient> ingredients)
{
    StringBuilder sb = new StringBuilder();
    foreach(var ingredient in ingredients)
    {
        sb.AppendLine($"{ingredient.Id}. {ingredient.Name}");
    }
    Console.WriteLine(sb.ToString());
}

void SelectIngredients()
{
    while (true)
    {
        Console.WriteLine("Add an ingredient by its ID or type anything else if finished.");
        string userInput = Console.ReadLine();
        if (!int.TryParse(userInput, out int id))
        {
            return;
        }
        var ingredient = ingredients.FirstOrDefault(i => i.Id == id);
        if (ingredient != null)
        {
            recipe.Add(ingredient);
        }
    }
}

bool IsRecipeValid()
{
    if(recipe.Count == 0)
    {
        Console.WriteLine("No ingredients have been selected. Recipe will not be saved.");
        return false;
    }
    Console.WriteLine("Recipe added:");
    PrintRecipe();
    return true;
}

void PrintRecipe()
{
    StringBuilder sb = new();
    foreach(var ingredient in recipe)
    {
        sb.AppendLine($"{ingredient.Name} {ingredient.Preparation}");
    }
    Console.WriteLine(sb.ToString());
}

void SaveRecipe()
{
    if(Settings.Format == FileFormat.Json)
    {
        new JsonFile().Save(path, recipe);
    }
    else
    {
        
    }
}

void LoadRecipes(string content, List<Ingredient> ingredients)
{
    if(Settings.Format == FileFormat.Json)
    {
        new JsonFile().Read(content, ingredients);
    }
}


public class JsonFile : IFileSave, IFileRead
{
    public void Read(string file, List<Ingredient> ingredients)
    {
        string content = File.ReadAllText(file);
        var idRows = JsonSerializer.Deserialize<List<List<int>>>(content);
        if (idRows == null || idRows.Count == 0) return;
        Console.WriteLine("Existing recipes are:");
        
        //for(int i = 0; i < idRows.Count; i++)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    Console.WriteLine($"***** {i + 1} *****");
        //    foreach (var id in idRows[i])
        //    {
        //        var ingredient = ingredients.FirstOrDefault(i => i.Id == id);
        //        if (ingredient is null) return;
        //        sb.AppendLine($"{ingredient.Name} {ingredient.Preparation}");
        //    }
        //    Console.WriteLine(sb.ToString());
        //}
    }

    public void Save(string path, List<Ingredient> recipe)
    {
        List<int> ids = new();
        foreach (var ingredient in recipe)
        {
            ids.Add(ingredient.Id);
        }
        path += "\\" + Settings.FileName + ".json";
        string content = JsonSerializer.Serialize(ids);
        File.AppendAllText(path, content + Environment.NewLine);
    }
}

public class TxtFile : IFileSave
{
    public void Save(string path, List<Ingredient> recipe)
    {
        throw new NotImplementedException();
    }
}

public interface IFileSave
{
    void Save(string file, List<Ingredient> recipe);
}

public interface IFileRead
{
    void Read(string file, List<Ingredient> ingredients);
}


public abstract class Ingredient
{
    public abstract int Id { get; }
    public abstract string Name { get; }
    public abstract string Preparation { get; }
}

public abstract class Flour : Ingredient
{
    public override string Preparation => "Sieve. Add to other ingredients.";
}

public abstract class Spice : Ingredient
{
    public override string Preparation => "Take half a teaspoon. Add to other ingredients.";
}



public class WheatFlour : Flour
{
    public override int Id => 1;

    public override string Name => "Wheat flour";
    
}

public class CoconutFlour : Flour
{
    public override int Id => 2;

    public override string Name => "Coconut flour";
}

public class Butter : Ingredient
{
    public override int Id => 3;

    public override string Name => "Butter";

    public override string Preparation => "Melt on low heat. Add to other ingredients.";
}

public class Chocolate : Ingredient
{
    public override int Id => 4;

    public override string Name => "Chocolate";

    public override string Preparation => "Melt in a water bath. Add to other ingredients.";
}

public class Sugar : Ingredient
{
    public override int Id => 5;

    public override string Name => "Sugar";

    public override string Preparation => "Add to other ingredients.";
}

public class Cardamom : Spice
{
    public override int Id => 6;

    public override string Name => "Cardamom";
}

public class Cinnamon : Spice
{
    public override int Id => 7;

    public override string Name => "Cinnamon";
}

public class CocoaPowder : Ingredient
{
    public override int Id => 8;

    public override string Name => "Cocoa powder";

    public override string Preparation => "Add to other ingredients.";
}
