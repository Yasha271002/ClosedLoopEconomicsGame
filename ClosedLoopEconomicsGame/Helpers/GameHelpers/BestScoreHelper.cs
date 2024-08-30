using System.IO;

namespace ClosedLoopEconomicsGame.Helpers.GameHelpers
{
    public static class BestScoreHelper
    {
        private static string _directory = "data";
        private static string _path = Path.Combine(_directory, "BestScore.txt");

        public static int Get()
        {
            if (!File.Exists(_path))
                return 0;

            var text = File.ReadAllText(_path);

            if (!int.TryParse(text, out var result))
                return 0;

            return result;
        }

        public static void CheckAndSave(int newValue)
        {
            if (!Directory.Exists(_directory))
                Directory.CreateDirectory(_directory);

            if (!File.Exists(_path))
            {
                File.WriteAllText(_path, newValue.ToString());
                return;
            }

            var bestScore = Get();

            if (newValue > bestScore)
                File.WriteAllText(_path, newValue.ToString());
        }
    }
}
