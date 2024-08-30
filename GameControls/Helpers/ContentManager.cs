using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Models;
using GameLibrary.Views.Controls;

namespace GameLibrary.Helpers
{
    public static class ContentManager
    {
        private static readonly string ContentDirectory = "content";
        private static readonly string ObjectsDirectory = Path.Combine(ContentDirectory, "objects");
        private static readonly string VideoDirectory = Path.Combine(ContentDirectory, "video");

        private static Dictionary<string, List<GameObjectModel>> GameObjects;
        
        public static Uri? VideoUri { get; private set; }

        public static void LoadContent()
        {
            LoadObjects();
            LoadVideo();
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

        private static void LoadVideo()
        {
            if (!Directory.Exists(VideoDirectory))
                return;

            var path = Directory.GetFiles(VideoDirectory).FirstOrDefault();
            VideoUri = path is null ? null :new Uri(path, UriKind.RelativeOrAbsolute);
        }
    }
}
