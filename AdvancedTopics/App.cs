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
        private readonly string[] options = ["population", "diameter", "surface water"];

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
            foreach(var option in options)
            {
                _userInteraction.ShowMessage(option);
            }
            string? selectedOption = _userInteraction.SelectOption();
            if(selectedOption is null || !options.Contains(selectedOption))
            {
                _userInteraction.ShowMessage("Invalid choice");
                return;
            }

            // Big violation of the DRY principle!
            PlanetDto minPlanet;
            PlanetDto maxPlanet;

            // I guess Reflection here??
            if (selectedOption == "population")
            {
                var min = planetsDto.Min(p => p.Population);
                minPlanet = planetsDto.FirstOrDefault(p => p.Population == min);

                var max = planetsDto.Max(p => p.Population);
                maxPlanet = planetsDto.FirstOrDefault(p => p.Population == max);

                _userInteraction.ShowMessage($"Max {selectedOption} is {max} (planet: {maxPlanet.Name})");
                _userInteraction.ShowMessage($"Min {selectedOption} is {min} (planet: {minPlanet.Name})");
            }
            if (selectedOption == "diameter")
            {
                var min = planetsDto.Min(p => p.Diameter);
                minPlanet = planetsDto.FirstOrDefault(p => p.Diameter == min);

                var max = planetsDto.Max(p => p.Diameter);
                maxPlanet = planetsDto.FirstOrDefault(p => p.Diameter == max);

                _userInteraction.ShowMessage($"Max {selectedOption} is {max} (planet: {maxPlanet.Name})");
                _userInteraction.ShowMessage($"Min {selectedOption} is {min} (planet: {minPlanet.Name})");
            }
            if (selectedOption == "surface water")
            {
                var min = planetsDto.Min(p => p.SurfaceWater);
                minPlanet = planetsDto.FirstOrDefault(p => p.SurfaceWater == min);

                var max = planetsDto.Max(p => p.SurfaceWater);
                maxPlanet = planetsDto.FirstOrDefault(p => p.SurfaceWater == max);

                _userInteraction.ShowMessage($"Max {selectedOption} is {max} (planet: {maxPlanet.Name})");
                _userInteraction.ShowMessage($"Min {selectedOption} is {min} (planet: {minPlanet.Name})");
            }
            
        }
    }
}
