using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Models
{
    public class GameObjectCategory
    {
        public string Name { get; set; }

        public GameObjectCategory(string name)
        {
            Name = name;
        }
    }
}
