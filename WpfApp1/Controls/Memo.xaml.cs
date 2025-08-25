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
using WpfApp1.Pages;

namespace WpfApp1.Controls
{
    /// <summary>
    /// Interaction logic for Memo.xaml
    /// </summary>
    public partial class Memo : UserControl
    {
        public Memo()
        {
            InitializeComponent();
            BuildMemo();
            
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

        private void BuildMemo()
        {
            titleTextBlock.Text = Title;
            contentTextBlock.Text = MemoContent;
            
        }

        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OpenEditWindow();
        }

        private void editMenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenEditWindow();
        }

        private void deleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App)!.Memos.Remove(this);
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
