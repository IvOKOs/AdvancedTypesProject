// See https://aka.ms/new-console-template for more information
using AdvancedTopics;
using System.Globalization;
using System.Text.Json.Serialization;


try
{
    App app = new App(new ApiReader(new ConsoleUserInteraction()),
                      new TablePrinter<PlanetDto>(new ConsoleUserInteraction()),
                      new ConsoleUserInteraction());
    await app.Run();
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}
Console.Write("Press any key to close.");
Console.ReadKey();



// going with struct since we only have value-type properties
public struct PlanetDto
{
    public string Name { get; init; }
    public int? Diameter { get; init; }
    public double? SurfaceWater { get; init; }
    public long? Population { get; init; }

    public static implicit operator PlanetDto(Planet planet)
    {
        return new PlanetDto
        {
            Name = planet.name,
            Diameter = planet.diameter.ToNullableInt(),
            SurfaceWater = planet.surface_water.ToNullableDouble(),
            Population = planet.population.ToNullableLong(),
        };
    }
}

public struct Planet
{
    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("rotation_period")]
    public string rotation_period { get; set; }

    [JsonPropertyName("orbital_period")]
    public string orbital_period { get; set; }

    [JsonPropertyName("diameter")]
    public string diameter { get; set; }

    [JsonPropertyName("climate")]
    public string climate { get; set; }

    [JsonPropertyName("gravity")]
    public string gravity { get; set; }

    [JsonPropertyName("terrain")]
    public string terrain { get; set; }

    [JsonPropertyName("surface_water")]
    public string surface_water { get; set; }

    [JsonPropertyName("population")]
    public string population { get; set; }

    [JsonPropertyName("residents")]
    public List<string> residents { get; set; }

    [JsonPropertyName("films")]
    public List<string> films { get; set; }

    [JsonPropertyName("created")]
    public DateTime created { get; set; }

    [JsonPropertyName("edited")]
    public DateTime edited { get; set; }

    [JsonPropertyName("url")]
    public string url { get; set; }
}

