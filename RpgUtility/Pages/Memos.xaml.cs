using System.Windows;
using System.Windows.Controls;

namespace RPGUtility.Pages
{
    /// <summary>
    /// Interaction logic for Memos.xaml
    /// </summary>
    public partial class Memos : Page
    {
        public Memos()
        {
            InitializeComponent();
            ((App)Application.Current).MemosPage = this;
        }

        private void addMemoButton_Click(object sender, RoutedEventArgs e)
        {
            new NewMemoWindow().Show();
        }

        public void RefreshMemos()
        {
            memosStackPanel.Children.Clear();
            foreach (var memo in ((App)Application.Current).Memos)
            {
                memosStackPanel.Children.Add(memo);
            }
        }

        private void clearMemosButton_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App)!.Memos.Clear();
        }

        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("""
                
                This page allows you to create and manage memos for your RPG campaigns. 
                
                Click the "Add Memo" button to create a new memo. You can use memos to jot down important information, reminders, or notes related to your game sessions.
                
                You can edit or delete existing memos by right-clicking or double-clicking on them.
                
                """, "Memos Help", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
