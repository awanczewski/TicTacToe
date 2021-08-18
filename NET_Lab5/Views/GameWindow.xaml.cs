using NET_Lab5.ViewModels;
using System.Windows;

namespace NET_Lab5
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new GameViewModel();
        }
    }
}
