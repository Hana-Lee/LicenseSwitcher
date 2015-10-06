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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ComboBox = System.Windows.Controls.ComboBox;
using MessageBox = System.Windows.MessageBox;
using TextBox = System.Windows.Forms.TextBox;

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

        private void VersionComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var comboBox = sender as ComboBox;

            var selectedValue = GetSelectedValueFromVersionComboBox(comboBox);
            if (selectedValue != null)
            {
                Fill_SettingValue(selectedValue);
            }
        }

        private void VersionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;

            var selectedValue = GetSelectedValueFromVersionComboBox(comboBox);
            if (selectedValue != null)
            {
                Fill_SettingValue(selectedValue);
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

        private void Fill_SettingValue(string selectedVersion)
        {
            var targetKey = selectedVersion + "_target";
            var licFolderKey = selectedVersion + "_lic_folder";
            var oracleKey = selectedVersion + "_oracle";
            var derbyKey = selectedVersion + "_derby";
            var mysqlKey = selectedVersion + "_mysql";
            var mssqlKey = selectedVersion + "_mssql";

            TargetTextBox.Text = (string) Properties.Settings.Default[targetKey];
            LicFolderTextBox.Text = (string) Properties.Settings.Default[licFolderKey];
            OracleTextBox.Text = (string) Properties.Settings.Default[oracleKey];
            MysqlTextBox.Text = (string) Properties.Settings.Default[mysqlKey];
            MssqlTextBox.Text = (string) Properties.Settings.Default[mssqlKey];
            DerbyTextBox.Text = (string) Properties.Settings.Default[derbyKey];
        }

        private void Show_TargetFolderSelectDialog(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog {ShowNewFolderButton = true};
            var selectedResult = dialog.ShowDialog();
            if (selectedResult != DialogResult.OK) return;

            TargetTextBox.Text = dialog.SelectedPath;
        }

        private void Show_LicFolderSelectDialog(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog { ShowNewFolderButton = true };
            var selectedResult = dialog.ShowDialog();
            if (selectedResult != DialogResult.OK) return;

            LicFolderTextBox.Text = dialog.SelectedPath;
        }

        private void Show_FileSelectDialog(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
