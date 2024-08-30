using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainComponents.Observable;

namespace GameLibrary.Models
{
    public class GameObjectModel : ObservableObject
    {
        public string? CategoryName
        {
            get => GetOrCreate<string?>();
            set => SetAndNotify(value);
        }

        public string? ImagePath
        {
            get => GetOrCreate<string?>();
            set => SetAndNotify(value);
        }
    }
}
