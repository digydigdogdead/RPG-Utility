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

namespace RPGUtility.Pages
{
    /// <summary>
    /// Interaction logic for MemoOverwriteWindow.xaml
    /// </summary>
    public partial class MemoOverwriteWindow : Window
    {
        public int Index;
        public MemoOverwriteWindow()
        {
            InitializeComponent();
        }

        private void overwriteMemoButton_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App)!.Memos[Index].Title = memoTitleTextBox.Text;
            (App.Current as App)!.Memos[Index].MemoContent = memoContentTextBox.Text;
            (App.Current as App)!.MemosPage?.RefreshMemos();
            this.Close();
        }

        private void deleteMemoButton_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App)!.Memos.RemoveAt(Index);
            (App.Current as App)!.MemosPage?.RefreshMemos();
            this.Close();
        }

        private void memoContentTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                overwriteMemoButton_Click(sender, e);
            }
        }
    }
}
