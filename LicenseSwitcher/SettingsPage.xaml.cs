using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using LicenseSwitcher.Properties;
using ComboBox = System.Windows.Controls.ComboBox;
using MessageBox = System.Windows.MessageBox;

namespace LicenseSwitcher
{
    /// <summary>
    ///     SettingsPage.xaml에 대한 상호 작용 논리
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
            Save_Settings();

            var result = MessageBox.Show("Settings save done!", "Information",
                MessageBoxButton.OK, MessageBoxImage.Information);

            if (result == MessageBoxResult.OK)
            {
                PageSwitcher.Switch(new MainPage());
            }
        }

        private void Save_Settings()
        {
            var versionValue = GetSelectedValueFromVersionComboBox(VersionComboBox);
            var targetValue = TargetTextBox.Text;
            var licFolderValue = LicFolderTextBox.Text;
            var oracleValue = OracleTextBox.Text;
            var mysqlValue = MysqlTextBox.Text;
            var mssqlValue = MssqlTextBox.Text;
            var derbyValue = DerbyTextBox.Text;

            Settings.Default.Version = versionValue;
            Settings.Default[versionValue + "_target"] = targetValue;
            Settings.Default[versionValue + "_lic_folder"] = licFolderValue;
            Settings.Default[versionValue + "_oracle"] = oracleValue;
            Settings.Default[versionValue + "_mysql"] = mysqlValue;
            Settings.Default[versionValue + "_mssql"] = mssqlValue;
            Settings.Default[versionValue + "_derby"] = derbyValue;
            Settings.Default.Save();
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

            TargetTextBox.Text = (string) Settings.Default[targetKey];
            LicFolderTextBox.Text = (string) Settings.Default[licFolderKey];
            OracleTextBox.Text = (string) Settings.Default[oracleKey];
            MysqlTextBox.Text = (string) Settings.Default[mysqlKey];
            MssqlTextBox.Text = (string) Settings.Default[mssqlKey];
            DerbyTextBox.Text = (string) Settings.Default[derbyKey];
        }

        private void Show_TargetFolderSelectDialog(object sender, RoutedEventArgs e)
        {
            TargetTextBox.Text = Get_SelectedPath();
        }

        private void Show_LicFolderSelectDialog(object sender, RoutedEventArgs e)
        {
            LicFolderTextBox.Text = Get_SelectedPath();
        }

        private static string Get_SelectedPath()
        {
            var dialog = new FolderBrowserDialog {ShowNewFolderButton = true};
            var selectedResult = dialog.ShowDialog();
            return selectedResult == DialogResult.OK ? dialog.SelectedPath : string.Empty;
        }

        private void Show_OracleFileSelectDialog(object sender, RoutedEventArgs e)
        {
            OracleTextBox.Text = Get_SelectedFileName();
        }

        private void Show_MysqlFileSelectDialog(object sender, RoutedEventArgs e)
        {
            MysqlTextBox.Text = Get_SelectedFileName();
        }

        private void Show_MssqlFileSelectDialog(object sender, RoutedEventArgs e)
        {
            MssqlTextBox.Text = Get_SelectedFileName();
        }

        private void Show_DerbyFileSelectDialog(object sender, RoutedEventArgs e)
        {
            DerbyTextBox.Text = Get_SelectedFileName();
        }

        private string Get_SelectedFileName()
        {
            var dialog = new OpenFileDialog
            {
                Filter = @"모든파일 (*.*)|*.*",
                Multiselect = false,
                InitialDirectory = LicFolderTextBox.Text
            };
            var selectedResult = dialog.ShowDialog();
            return selectedResult == DialogResult.OK ? dialog.FileName : string.Empty;
        }
    }
}