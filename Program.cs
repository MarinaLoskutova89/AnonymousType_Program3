
using System.Linq;

namespace Program3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var planets = new PlanetCatalog(new("Venus", 2, 38025), new("Earth", 3, 40075), new("Mars", 4, 21344));
            var inputs = new List<string>() { "Earth", "Lemonia", "Mars" };
            int _counter = 1;
            List<string> avaliablePlanet = planets.planets.Select(r => r.Name).ToList();

            foreach (var input in inputs)
            {
                var planet = planets.GetPlanet(input, i =>
                {
                    if (_counter >= 3) return "You ask too often!";
                    else if (!avaliablePlanet.Contains(input)) return $"{input} this is a forbidden planet";
                    else return null;
                });

                if (planet.serialNumberFromTheSun != 0)
                {
                    if (!string.IsNullOrEmpty(planet.errorMessage))
                    { 
                        Console.WriteLine(planet.errorMessage);
                        Console.WriteLine();
                    }
                    Console.WriteLine($"Name: {input}, SerialNumberFromTheSun: {planet.serialNumberFromTheSun}, EquatorLength: {planet.equatorLength}");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine(planet.errorMessage);
                    Console.WriteLine();
                }
                _counter++;
            }
        }
    }
}
