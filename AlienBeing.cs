using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Femme.ProgramUI;

namespace Femme
{
    public class AlienBeing
    {
        public string Name { get; }
        public string Description { get; }
        public string Quote { get; set; }


        public AlienBeing(string name, string description, string quote)
        {
            Name = name;
            Description = description;
            Quote = quote;
        }

        public void alienInfo(AlienBeing alien)
        {
            Console.WriteLine(alien.Description);
            Console.WriteLine(alien.Quote);
        }
    }
}
