using Core;

namespace ClosedLoopEconomicsGame.Model.GameModels
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
