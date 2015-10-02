using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LicenseSwitcher
{
    /// <summary>
    /// SettingsPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            PageSwitcher.Switch(new MainPage());
        }

        private void SaveBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Settings save done!", "Information", 
                MessageBoxButton.OK, MessageBoxImage.Information);

            if (result == MessageBoxResult.OK)
            {
                PageSwitcher.Switch(new MainPage());
            }
        }
    }
}
