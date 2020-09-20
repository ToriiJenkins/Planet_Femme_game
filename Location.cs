using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Femme.ProgramUI;

namespace Femme
{
    public class Location
    {
        public string Splash { get; }

        public List<string> Paths { get; }

        public List<Item> Items { get; }

        public string ItemImage { get; set; }

        public List<AlienBeing> Inhabitants { get; set; }

        public Location(string splash, List<string> paths, List<Item> items, string itemImage, List<AlienBeing> inhabitants)
        {
            Splash = splash;
            Paths = paths;
            Items = items;
            ItemImage = itemImage;
        }

        public void RemoveItem(Item item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
                
            }
        }

        public void RemoveImage(Location location)
        {

            location.ItemImage = "";
            
        }
    }
}
