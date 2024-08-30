using ClosedLoopEconomicsGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosedLoopEconomicsGame.Helpers
{
    public class PopupParametersHelper
    {
        public CategoryInfoModel CategoryInfo { get; set; }
        public string SelectedImagePath { get; set; }

        public PopupParametersHelper(CategoryInfoModel categoryInfo, string selectedImagePath)
        {
            CategoryInfo = categoryInfo;
            SelectedImagePath = selectedImagePath;
        }
    }
}
