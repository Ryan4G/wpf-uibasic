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

namespace UIDataTemplate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Student> students = new List<Student>();
            students.Add(new Student { UserName = "小明", ClassName = "三年二班", Address = "北京" });
            students.Add(new Student { UserName = "小红", ClassName = "三年一班", Address = "湖北" });
            students.Add(new Student { UserName = "小华", ClassName = "三年二班", Address = "山西" });
            students.Add(new Student { UserName = "小杰", ClassName = "四年一班", Address = "天津" });
            students.Add(new Student { UserName = "小丫", ClassName = "四年二班", Address = "海南" });

            gd.ItemsSource = students;

            List<CustomColor> colors = new List<CustomColor>();
            colors.Add(new CustomColor { Code = Colors.AliceBlue.ToString() });
            colors.Add(new CustomColor { Code = Colors.Blue.ToString() });
            colors.Add(new CustomColor { Code = Colors.Brown.ToString() });
            colors.Add(new CustomColor { Code = Colors.Aqua.ToString() });
            colors.Add(new CustomColor { Code = Colors.SeaGreen.ToString() });
            colors.Add(new CustomColor { Code = Colors.Violet.ToString() });
            colors.Add(new CustomColor { Code = Colors.YellowGreen.ToString() });
            lib.ItemsSource = colors;
            cob.ItemsSource = colors;

            List<CustomData> customDatas = new List<CustomData>();
            customDatas.Add(new CustomData { Code = "NO.1" });
            customDatas.Add(new CustomData { Code = "NO.2" });
            customDatas.Add(new CustomData { Code = "NO.3" });
            customDatas.Add(new CustomData { Code = "NO.4" });
            customDatas.Add(new CustomData { Code = "NO.5" });
            ic.ItemsSource = customDatas;
        }
    }

    public class Student
    {
        public string UserName { get; set; }

        public string ClassName { get; set; }

        public string Address { get; set; }
    }

    public class CustomColor
    {
        public string Code { get; set; }
    }

    public class CustomData
    {
        public string Code { get; set; }
    }
}
