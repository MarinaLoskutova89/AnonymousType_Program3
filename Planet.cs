using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program3
{
    public class Planet
    {
        public Planet(string name, int serialNumberFromTheSun, int equatorLength)
        {
            this.Name = name;
            this.SerialNumberFromTheSun = serialNumberFromTheSun;
            this.EquatorLength = equatorLength;
        }
        public string Name { get; set; }
        public int SerialNumberFromTheSun { get; set; }
        public int EquatorLength { get; set; }
        public Planet? PreviousPlanet { get; set; }
    }
}
