using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace ClosedLoopEconomicsGame.Model
{
    public class ResultGameModel : ObservableObject
    {
        public string? Title
        {
            get => GetOrCreate<string?>();
            set => SetAndNotify(value);
        }

        public string? Description
        {
            get => GetOrCreate<string?>();
            set => SetAndNotify(value);
        }

        public string? ImagePath
        {
            get => GetOrCreate<string?>();
            set => SetAndNotify(value);
        }

        public bool Replay
        {
            get => GetOrCreate<bool>();
            set => SetAndNotify(value);
        }
    }
}
