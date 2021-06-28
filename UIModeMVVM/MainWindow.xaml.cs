using System.Windows;
using UIModeMVVM.ViewModel;

namespace UIModeMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainViewModel mainViewModel = new MainViewModel();
            mainViewModel.Query();

            this.DataContext = mainViewModel;
        }
    }
}
