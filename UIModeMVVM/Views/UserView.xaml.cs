﻿using System;
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
using System.Windows.Shapes;
using UIModeMVVM.Models;

namespace UIModeMVVM.Views
{
    /// <summary>
    /// UserView.xaml 的交互逻辑
    /// </summary>
    public partial class UserView : Window
    {
        public UserView(Student student)
        {
            InitializeComponent();

            this.DataContext = new
            {
                Model = student
            };
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
