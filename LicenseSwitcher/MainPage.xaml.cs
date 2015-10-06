using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using LicenseSwitcher.Properties;

namespace LicenseSwitcher
{
    /// <summary>
    ///     MainPage.xaml에 대한 상호 작용 논리
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
            var selectedVersionValue = GetSelectedValueFromVersionComboBox(VersionCombo);
            if (selectedVersionValue != null)
            {
                OutputMsg.Text = " * " + selectedVersionValue + " 버전 준비 완료.\n";
            }
        }

        private void VersionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedVersionValue = GetSelectedValueFromVersionComboBox(VersionCombo);
            if (selectedVersionValue != null)
            {
                OutputMsg.Text = " * " + selectedVersionValue + " 버전 준비 완료.\n";
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

        private void SettingsBtn_OnClick(object sender, RoutedEventArgs e)
        {
            PageSwitcher.Switch(new SettingsPage());
        }

        private void LicenseSwitchBtn_OnClick(object sender, RoutedEventArgs e)
        {
            OutputMsg.Text = "============================\n";
            OutputMsg.Text += " * 라이센스 파일 변경 준비...\n";

            var selectedDatabaseValue = TogaProperties.Get("dataSource.url");
            string selectedDatabase;
            if (selectedDatabaseValue.ToLower().Contains(SupportedDatabase.mysql.ToString()))
            {
                selectedDatabase = "mysql";
            }
            else if (selectedDatabaseValue.ToLower().Contains(SupportedDatabase.oracle.ToString()))
            {
                selectedDatabase = "oracle";
            }
            else if (selectedDatabaseValue.ToLower().Contains(SupportedDatabase.sqlserver.ToString()))
            {
                selectedDatabase = "mssql";
            }
            else
            {
                selectedDatabase = "derby";
            }

            OutputMsg.Text += " * 적용 대상 데이터 베이스 : " + selectedDatabase.ToUpper() + "\n";

            LicenseFile_Switch(selectedDatabase);
        }

        private void LicenseFile_Switch(string selectedDatabase)
        {
            var selectedVersion = GetSelectedValueFromVersionComboBox(VersionCombo);
            var targetFolder = (string) Settings.Default[selectedVersion + "_target"];
            var licFolder = (string) Settings.Default[selectedVersion + "_lic_folder"];
            var licFile = (string) Settings.Default[selectedVersion + "_" + selectedDatabase];
            var srcLicFileFullPath = licFile;
            var destTogaAdminLicFileFullPath = Path.Combine(targetFolder, "toga-admin", "src", "main", "resources",
                "toga.lic");
            var destTogaWebLicFileFullPath = Path.Combine(targetFolder, "kona-web", "src", "main", "resources",
                "toga.lic");

            if (!licFile.Contains(":"))
            {
                srcLicFileFullPath = Path.Combine(licFolder, licFile);
            }

            if (!Directory.Exists(targetFolder))
            {
                MessageBox.Show("라이센스를 복사 하려는 디렉토리가 존재하지 않습니다.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                OutputMsg.Text += " * 변경 실패 : 라이센스를 복사 하려는 디렉토리가 존재하지 않습니다.\n";
                return;
            }

            if (!Directory.Exists(Path.Combine(targetFolder, "toga-admin")))
            {
                MessageBox.Show("toga-admin 디렉토리가 존재하지 않습니다.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                OutputMsg.Text += " * 변경 실패 : toga-admin 디렉토리가 존재하지 않습니다.\n";
                return;
            }

            if (!Directory.Exists(Path.Combine(targetFolder, "kona-web")))
            {
                MessageBox.Show("kona-web 디렉토리가 존재하지 않습니다.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                OutputMsg.Text += " * 변경 실패 : kona-web 디렉토리가 존재하지 않습니다.\n";
                return;
            }

            File.Copy(srcLicFileFullPath, destTogaAdminLicFileFullPath, true);
            File.Copy(srcLicFileFullPath, destTogaWebLicFileFullPath, true);

            MessageBox.Show("라이센스 변경 완료!!!", "Information",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            OutputMsg.Text += " * 라이센스 변경 완료!!!\n";
            OutputMsg.Text += " * 변경 완료 시각\n";
            OutputMsg.Text += " * " + DateTime.Now + "\n";
            OutputMsg.Text += "============================\n";
        }
    }
}