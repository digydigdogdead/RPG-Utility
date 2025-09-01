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
            RefreshMemos();
        }
    }
}
