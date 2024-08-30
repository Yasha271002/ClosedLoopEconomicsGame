using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameLibrary.Helpers
{
    public class PageProvider
    {
        private readonly Func<Page> _pageFunc;

        public PageProvider(Func<Page> pageFunc)
        {
            _pageFunc = pageFunc;
        }

        public Page GetPage()
        {
            return _pageFunc();
        }
    }
}
