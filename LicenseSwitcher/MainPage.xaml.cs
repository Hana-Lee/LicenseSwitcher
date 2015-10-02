using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// MainPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void VersionComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            //List<string> data = new List<string>();
            //data.Add("trunk");
            //data.Add("4.1");
            //data.Add("4.0");

            //var comboBox = sender as ComboBox;
            //comboBox.ItemsSource = data;
            //comboBox.SelectedIndex = 0;

            WriteToOutputTextBox(sender);
        }

        private void VersionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            WriteToOutputTextBox(sender);
        }

        private void WriteToOutputTextBox(object sender)
        {
            var comboBox = sender as ComboBox;
            if (OutputMsg == null) return;

            var selectedValue = GetSelectedValueFromVersionComboBox(comboBox);
            if (selectedValue != null)
            {
                OutputMsg.Text = selectedValue;
            }
        }

        private static string GetSelectedValueFromVersionComboBox(Selector versionComboBox)
        {
            var selectedValue = "";
            if (versionComboBox == null) return selectedValue;

            var selectedItem = versionComboBox.SelectedItem as ComboBoxItem;

            if (selectedItem != null)
            {
                selectedValue = selectedItem.Content as string;
            }

            return selectedValue;
        }
    }
}