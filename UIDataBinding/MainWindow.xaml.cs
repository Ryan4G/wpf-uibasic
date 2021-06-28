using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace UIDataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            txt_new.DataContext = new Person
            {
                Name = "Tom张"
            };

            //this.DataContext = new MainViewModel { MainName = "艾AB" };
            this.DataContext = new MVVMViewModel();
        }
    }

    public class Person
    {
        public string Name { get; set; }
    }

    public class MainViewModel
    {
        public string MainName { get; set; }
    }

    public class DynamicViewModel : INotifyPropertyChanged
    {
        public DynamicViewModel()
        {
            dynamicName = "成心Asabell";

            Task.Run(async () => { 
                await Task.Delay(3000); 
                DynamicName = "MyBabyGO.."; 
            });
        }

        private string dynamicName;

        public string DynamicName
        {
            get { return dynamicName; }
            set
            {

                dynamicName = value;
                OnPropertyChanged("DynamicName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class MVVMViewModel : ViewModelBase
    {
        public MVVMViewModel()
        {
            dynamicName = "第三方初始化";

            SaveCommand = new RelayCommand(() => {
                DynamicName = "初始化完毕";
            });
        }

        private string dynamicName;

        public string DynamicName
        {
            get { return dynamicName; }
            set
            {

                dynamicName = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand SaveCommand { get; private set; }
    }
}
