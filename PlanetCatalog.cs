using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Program3
{
    public class PlanetCatalog
    {
        public List<Planet> planets = new();
        private int _serialNumberFromTheSun;
        private int _equatorLength;
        private string? _errorMessage;
        private Planet? _head;
        public delegate string PlanetValidator(string planetName);

        public PlanetCatalog(params Planet[] inputs)
        {
            var listOfInputs = new List<Planet>();
            foreach (var input in inputs)
            {
                var newHead = new Planet(input.Name, input.SerialNumberFromTheSun, input.EquatorLength);
                newHead.PreviousPlanet = _head;
                _head = newHead;
                listOfInputs.Add(newHead);
            }
            this.planets = listOfInputs;
        }

        public (int serialNumberFromTheSun, int equatorLength, string? errorMessage) GetPlanet(string planetName, PlanetValidator validator) 
        {
            _serialNumberFromTheSun = 0;
            _equatorLength = 0;
            _errorMessage = string.Empty;

            if (!string.IsNullOrEmpty(validator(planetName)))
            { 
                _errorMessage = validator(planetName); 
            }

            Planet? planet = planets.Where(r => r.Name == planetName).FirstOrDefault();

            if (planet is not null)
            {
                _serialNumberFromTheSun = planet.SerialNumberFromTheSun;
                _equatorLength = planet.EquatorLength;
            }

            return (_serialNumberFromTheSun, _equatorLength, _errorMessage);
        }
    }
}
