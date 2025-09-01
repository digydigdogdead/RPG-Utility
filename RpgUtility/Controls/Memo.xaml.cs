using System.Windows;
using System.Windows.Controls;
using RPGUtility.Pages;

namespace RPGUtility.Controls
{
    /// <summary>
    /// Interaction logic for Memo.xaml
    /// </summary>
    public partial class Memo : UserControl
    {
        public Memo()
        {
            InitializeComponent();
            titleTextBlock.Text = Title;
            contentTextBlock.Text = MemoContent;
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            nameof(Title), typeof(string), typeof(Memo), new PropertyMetadata("Memo Title", OnTitleChanged()));
        public string Title 
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty MemoContentProperty = DependencyProperty.Register(
            nameof(MemoContent), typeof(string), typeof(Memo), new PropertyMetadata("Example of a memo...", OnMemoContentChanged()));
        public string MemoContent 
        {
            get { return (string)GetValue(MemoContentProperty); }
            set { SetValue(MemoContentProperty, value); }
        }

        private static PropertyChangedCallback OnTitleChanged()
        {
            return (d, e) =>
            {
                Memo memo = (Memo)d;
                if (memo.titleTextBlock != null)
                {
                    memo.titleTextBlock.Text = memo.Title;
                }
            };
        }

        private static PropertyChangedCallback OnMemoContentChanged()
        {
            return (d, e) =>
            {
                Memo memo = (Memo)d;
                if (memo.contentTextBlock != null)
                {
                    if (memo.MemoContent.Length < 90)
                    { memo.contentTextBlock.Text = memo.MemoContent; }
                    else
                    {
                        memo.contentTextBlock.Text = memo.MemoContent.Substring(0, 90) + "...";
                    }
                    ToolTipService.SetToolTip(memo.contentTextBlock, memo.MemoContent);
                }
            };
        }

        private void OpenEditWindow(object sender, EventArgs e)
        {
            OpenEditWindow();
        }

        private void deleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App)!.Memos?.Remove(this);
            (App.Current as App)!.MemosPage?.RefreshMemos();
        }

        private void OpenEditWindow()
        {
            int index = ((App)Application.Current).Memos.IndexOf(this);
            MemoOverwriteWindow overwriteMemoWindow = new MemoOverwriteWindow();
            overwriteMemoWindow.Index = index;
            overwriteMemoWindow.memoTitleTextBox.Text = this.Title;
            overwriteMemoWindow.memoContentTextBox.Text = this.MemoContent;
            overwriteMemoWindow.Show();
        }
    }
}
