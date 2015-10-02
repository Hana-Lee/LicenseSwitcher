using System.Windows.Controls;

namespace LicenseSwitcher
{
    public static class PageSwitcher
    {
        public static MainWindow LicenseSwitcherMainWindow;

        public static void Switch(Page page)
        {
            LicenseSwitcherMainWindow.Navigate(page);
        }
    }
}