using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;

namespace SleepDown
{

    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        private NotifyIconWrapper notifyIcon;


        /// <summary>
        /// System.Windows.Application.Startup イベント を発生させます。
        /// </summary>
        /// <param name="e">イベントデータ を格納している StartupEventArgs</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            this.notifyIcon = new NotifyIconWrapper();
            if (SleepDown.Properties.Settings.Default.FilePath == "false")
            {
                SleepDown.Properties.Settings.Default.FilePath = System.IO.Directory.GetCurrentDirectory() + "/SampleSound/sample0.mp3";
            }
            StartWakeupTime();
            

        }

        /// <summary>
        /// System.Windows.Application.Exit イベント を発生させます。
        /// </summary>
        /// <param name="e">イベントデータ を格納している ExitEventArgs</param>
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            this.notifyIcon.Dispose();

            Application.Current.Shutdown();
        }

        public async void StartWakeupTime()
        {
            double CallTime = SleepDown.Properties.Settings.Default.AlertTime * 60000;
            await Task.Run(() =>
            {
                while (true)
                {
                    TimeSpan last_input_time = User32Interop.GetLastInput();

                    if ((double)last_input_time.TotalMilliseconds > CallTime)
                    {
                        PlaySound();
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            });
        }

        public static void PlaySound()
        {
            string SoundFilePath = SleepDown.Properties.Settings.Default.FilePath;
            string FileExtension = System.IO.Path.GetExtension(SoundFilePath);
            switch (FileExtension)
            {
                case ".mp3"://This is fall through so it's not that i forget break
                case ".wav":
                case ".flac":
                    Microsoft.SmallBasic.Library.Sound.PlayAndWait(SoundFilePath);
                    break;

                default:
                    MessageBox.Show("音声ファイルは\n対応した拡張子を設定してください");
                    break;
            }
        }

        public static class User32Interop
        {
            /// <summary>
            /// 最終操作からの経過時間
            /// MessageBox.Show(User32Interop.GetLastInput().TotalMilliseconds.ToString());
            /// </summary> ミリ秒で表示される Ex. 1sec -> 1000, 5sec -> 5000
            /// <returns></returns>
            public static TimeSpan GetLastInput()
            {
                var plii = new LASTINPUTINFO();
                plii.cbSize = (uint)Marshal.SizeOf(plii);
                if (GetLastInputInfo(ref plii))
                    return TimeSpan.FromMilliseconds(Environment.TickCount - plii.dwTime);
                else
                    throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
            }

            [DllImport("user32.dll", SetLastError = true)]
            static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);
            struct LASTINPUTINFO
            {
                public uint cbSize;
                public uint dwTime;
            }
        }
    }
}
