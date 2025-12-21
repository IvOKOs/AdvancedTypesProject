using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdvancedTopics
{
    public class App
    {
        private IApiReader _apiReader;
        private IPrinter<PlanetDto> _printer;
        private IUserInteraction _userInteraction;

        private readonly Dictionary<string, Func<PlanetDto, dynamic?>> optionToValueMapping = new()
        {
            ["population"] = p => p.Population,
            ["diameter"] = p => p.Diameter,
            ["surface water"] = p => p.SurfaceWater,
        };


        public App(IApiReader apiReader, IPrinter<PlanetDto> printer, IUserInteraction userInteraction)
        {
            _apiReader = apiReader;
            _printer = printer;
            _userInteraction = userInteraction;
        }

        public async Task Run()
        {
            string json = await _apiReader.GetJsonAsync("https://swapi.info/api/", "planets");
            List<Planet>? planets = JsonSerializer.Deserialize<List<Planet>>(json);
            if(planets is null)
            {
                _userInteraction.ShowMessage("There are no planets to see.");
                return;
            }
            List<PlanetDto> planetsDto = new();
            foreach(var planet in planets)
            {
                PlanetDto planetDto = planet;
                planetsDto.Add(planetDto);
            }
            _printer.Print(planetsDto);
            _userInteraction.ShowMessage("The statistics of which property would you like to see?");
            _userInteraction.ShowMessage(string.Join(Environment.NewLine, optionToValueMapping.Keys));
            string? selectedOption = _userInteraction.SelectOption();

            if (selectedOption is null || !optionToValueMapping.ContainsKey(selectedOption))
            {
                _userInteraction.ShowMessage("Invalid choice");
            }
            else
            {
                ShowStatistics(planetsDto, selectedOption, optionToValueMapping[selectedOption]);
            }
        }

        private void ShowStatistics(IEnumerable<PlanetDto> planets,
                                    string propName,
                                    Func<PlanetDto, dynamic?> propSelector)
        {
            var minPlanet = planets.MinBy(propSelector);
            var maxPlanet = planets.MaxBy(propSelector);

            _userInteraction.ShowMessage($"Max {propName} is {propSelector(maxPlanet)} (planet: {maxPlanet.Name})");
            _userInteraction.ShowMessage($"Min {propName} is {propSelector(minPlanet)} (planet: {minPlanet.Name})");
        }
    }
}
