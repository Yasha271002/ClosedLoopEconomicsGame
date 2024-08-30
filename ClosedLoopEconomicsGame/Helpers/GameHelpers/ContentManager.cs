using System.IO;
using ClosedLoopEconomicsGame.Model.GameModels;

namespace ClosedLoopEconomicsGame.Helpers.GameHelpers
{
    public static class ContentManager
    {
        private static readonly string ContentDirectory = "Content";
        private static readonly string ObjectsDirectory = Path.Combine(ContentDirectory, "GameContent");

        private static Dictionary<string, List<GameObjectModel>> GameObjects;
        
        public static void LoadContent()
        {
            LoadObjects();
        }

        public static List<GameObjectModel> GetObjectsByCategory(string categoryName)
        {
            if (!GameObjects.ContainsKey(categoryName))
                return new List<GameObjectModel>();

            return GameObjects[categoryName];
        }

        private static void LoadObjects()
        {
            if (!Directory.Exists(ObjectsDirectory))
                return;

            GameObjects = Directory.GetDirectories(ObjectsDirectory)
                .ToDictionary(Path.GetFileName, GetObjectsFromDirectory);
        }

        private static List<GameObjectModel> GetObjectsFromDirectory(string objectCategoryDirectory)
        {
            return Directory.GetFiles(objectCategoryDirectory)
                .Where(IsImage)
                .Select(path => new GameObjectModel
                {
                    CategoryName = Path.GetFileName(objectCategoryDirectory),
                    ImagePath = path
                })
                .ToList();
        }

        private static bool IsImage(string path)
        {
            return Path.GetExtension(path) == ".png";
        }
    }
}
