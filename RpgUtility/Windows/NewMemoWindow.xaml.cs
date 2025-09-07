using System.Windows;
using System.Windows.Input;
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
                if (Keyboard.IsKeyDown(Key.LeftShift))
                {
                    memoContentTextBox.Text += Environment.NewLine;
                    memoContentTextBox.CaretIndex = memoContentTextBox.Text.Length;
                }
                else saveMemoButton_Click(sender, e);
            }
        }
    }
}
