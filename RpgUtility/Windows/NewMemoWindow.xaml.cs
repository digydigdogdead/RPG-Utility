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
using System.Windows.Shapes;
using RPGUtility.Controls;

namespace RPGUtility.Pages
{
    /// <summary>
    /// Interaction logic for NewMemoWindow.xaml
    /// </summary>
    public partial class NewMemoWindow : Window
    {
        public NewMemoWindow()
        {
            InitializeComponent();
        }

        private void saveMemoButton_Click(object sender, RoutedEventArgs e)
        {
            Memo memo = new Memo();
            memo.Title = memoTitleTextBox.Text;
            memo.MemoContent = memoContentTextBox.Text;
            ((App)Application.Current).Memos.Add(memo);
            ((App)Application.Current).MemosPage?.RefreshMemos();
            this.Close();
        }

        private void memoContentTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                saveMemoButton_Click(sender, e);
            }
        }
    }
}
