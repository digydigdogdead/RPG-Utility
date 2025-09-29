using System.Windows;
using System.Windows.Input;

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
            (App.Current as App)!.Memos = new((App.Current as App)!.Memos);
            this.Close();
        }

        private void deleteMemoButton_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App)!.Memos.RemoveAt(Index);
            (App.Current as App)!.MemosPage?.RefreshMemos();
            (App.Current as App)!.Memos = new((App.Current as App)!.Memos);
            this.Close();
        }

        private void memoContentTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftShift)) memoContentTextBox.AcceptsReturn = true;

            if (e.Key == Key.Enter) overwriteMemoButton_Click(sender, e);
        }

        private void memoContentTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftShift) memoContentTextBox.AcceptsReturn = false;
        }
    }
}
