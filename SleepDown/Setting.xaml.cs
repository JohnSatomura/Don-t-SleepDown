using Microsoft.SmallBasic.Library;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SleepDown
{
    /// <summary>
    /// Setting.xaml の相互作用ロジック
    /// </summary>
    public partial class Setting : Window
    {
        string SoundFilePath;
        int TimeUnit = 1;
        public Setting()
        {
            InitializeComponent();
            
            // 現在のファイル名の変更
            CurrentSoundFile.Content = Path.GetFileName(SleepDown.Properties.Settings.Default.FilePath);
            RingSoundTime.Text = SleepDown.Properties.Settings.Default.AlertTime.ToString();
            SoundFilePath = SleepDown.Properties.Settings.Default.FilePath;
            TimeUnit = SleepDown.Properties.Settings.Default.TimeUnit;
            switch(TimeUnit)
            { 
                case 1:
                    UnitTimeComboBox.Text = "秒";
                    break;
                case 60:
                    UnitTimeComboBox.Text = "分";
                    break;
                case 3600:
                    UnitTimeComboBox.Text = "時間";
                    break;
            }
            comboBox.Text = Path.GetFileName(SleepDown.Properties.Settings.Default.FilePath);
        }

        private void SoundSample_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectLocalFile.Visibility = Visibility.Hidden;
            string CurrentDirectory = System.IO.Directory.GetCurrentDirectory();
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    SoundFilePath = CurrentDirectory + "/SampleSound/sample0.mp3";
                    break;
                case 1:
                    SoundFilePath = CurrentDirectory + "/SampleSound/sample1.mp3";
                    break;
                case 2:
                    SoundFilePath = CurrentDirectory + "/SampleSound/sample2.mp3";
                    break;
                case 3:
                    SoundFilePath = CurrentDirectory + "/SampleSound/sample3.mp3";
                    break;
                case 4:
                    SoundFilePath = CurrentDirectory + "/SampleSound/sample4.mp3";
                    break;
                case 5:
                    SoundFilePath = CurrentDirectory + "/SampleSound/sample5.wav";
                    break;
                case 6:
                    SelectLocalFile.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
        }
        private void timeUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (UnitTimeComboBox.SelectedIndex)
            {
                case 0:
                    TimeUnit = 1;
                    break;
                case 1:
                    TimeUnit = 60;
                    break;
                case 2:
                    TimeUnit = 3600;
                    break;
                default:
                    break;
            }
        }

        private void SelectLocalFileButton_Click(object sender, RoutedEventArgs e)
        {
            var FileDialog = new Microsoft.Win32.OpenFileDialog();
            FileDialog.Title = "開くファイルを選択してください";
            FileDialog.Filter = "mp3ファイル|*.mp3|wavファイル|*.wav|flacファイル|*.flac";

            if (FileDialog.ShowDialog() == true)
            {
                SoundFilePath = FileDialog.FileName;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            if (SoundFilePath != "") {
                SleepDown.Properties.Settings.Default.FilePath = SoundFilePath;
            }
            if (RingSoundTime.Text != "")
            {
                SleepDown.Properties.Settings.Default.AlertTime = int.Parse(RingSoundTime.Text);
            }
            SleepDown.Properties.Settings.Default.TimeUnit = TimeUnit;
            Properties.Settings.Default.Save();
            
        }


        private void TextBox_KeyDown(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
            //0～9と、バックスペース以外の時は、イベントをキャンセルする

        }
    }
}
