namespace ClosedLoopEconomicsGame.Model
{
    public class CategoryInfoModel
    {
        public string? LeftImagePath { get; set; }
        public string? TopImagePath { get; set; }
        public string? RightImagePath { get; set; }
        public string? BottomImagePath { get; set; }

        public List<string> GetImagePaths()
        {
            var imagePaths = new List<string>();

            if (!string.IsNullOrEmpty(LeftImagePath)) imagePaths.Add(LeftImagePath);
            if (!string.IsNullOrEmpty(TopImagePath)) imagePaths.Add(TopImagePath);
            if (!string.IsNullOrEmpty(RightImagePath)) imagePaths.Add(RightImagePath);
            if (!string.IsNullOrEmpty(BottomImagePath)) imagePaths.Add(BottomImagePath);

            return imagePaths;
        }
    }
}
