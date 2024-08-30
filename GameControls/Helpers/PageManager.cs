using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Views.Pages;

namespace GameLibrary.Helpers
{
    public static class PageManager
    {
        public static PageProvider? StartPage { get; set; }
        public static PageProvider VideoPage { get; } = new PageProvider(() => new VideoPage()); 
        public static PageProvider? GamePage { get; set; }
    }
}
