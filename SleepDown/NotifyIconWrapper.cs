using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace SleepDown
{
    public partial class NotifyIconWrapper : Component
    {
        public NotifyIconWrapper()
        {
            InitializeComponent();

            this.toolStripMenuItem_Open.Click += this.ToolStripMenuItem_Open_Click;
            this.toolStripMenuItem_Exit.Click += this.ToolStripMenuItem_Exit_Click;
            this.settingOpen.Click += this.SettingOpen_Click;
        }

        public NotifyIconWrapper(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        /// <summary>
        /// コンテキストメニュー "表示" を選択したとき呼ばれます。
        /// </summary>
        /// <param name="sender">呼び出し元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void ToolStripMenuItem_Open_Click(object sender, EventArgs e)
        {
            // MainWindow を生成、表示
            var window = new MainWindow();
            window.Show();
        }

        /// <summary>
        /// コンテキストメニュー "設定" を選択したとき呼ばれます。
        /// </summary>
        private void SettingOpen_Click(object sender, EventArgs e)
        {
            var SettingWindow = new Setting();
            SettingWindow.Show();
        }
        /// <summary>
        /// コンテキストメニュー "終了" を選択したとき呼ばれます。
        /// </summary>
        private void ToolStripMenuItem_Exit_Click(object sender, EventArgs e)
        {
            // 現在のアプリケーションを終了
            Application.Current.Shutdown();
        }
    }
}
