﻿using Microsoft.SmallBasic.Library;
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
        public Setting()
        {
            InitializeComponent();

            // 現在のファイル名の変更
            CurrentSoundFile.Content = Path.GetFileName(SleepDown.Properties.Settings.Default.FilePath);
            RingSoundTime.Text = SleepDown.Properties.Settings.Default.AlertTime.ToString();
            SoundFilePath = SleepDown.Properties.Settings.Default.FilePath;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            button.Visibility = Visibility.Hidden;
            string CurrentDirectory = System.IO.Directory.GetCurrentDirectory();
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    SoundFilePath = CurrentDirectory + "/SampleSound/cymbal.mp3";
                    break;
                case 1:
                    SoundFilePath = CurrentDirectory + "/SampleSound/daughter.mp3";
                    break;
                case 2:
                    SoundFilePath = CurrentDirectory + "/SampleSound/daughter.mp3";
                    break;
                case 3:
                    SoundFilePath = CurrentDirectory + "/SampleSound/daughter.mp3";
                    break;
                case 4:
                    SoundFilePath = CurrentDirectory + "/SampleSound/daughter.mp3";
                    break;
                case 5:
                    SoundFilePath = CurrentDirectory + "/SampleSound/daughter.mp3";
                    break;
                case 6:
                    button.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var FileDialog = new Microsoft.Win32.OpenFileDialog();
            FileDialog.Title = "開くファイルを選択してください";
            FileDialog.Filter = "mp3ファイル|*.mp3|wavファイル|*.wav|flacファイル|*.flac";
            
            if (FileDialog.ShowDialog() == true)
            {
                SoundFilePath = FileDialog.FileName;
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(SoundFilePath);
            this.Close();
            SleepDown.Properties.Settings.Default.FilePath = SoundFilePath;
            SleepDown.Properties.Settings.Default.AlertTime = Convert.ToDouble(RingSoundTime.Text);
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
