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

namespace AutoCoder
{
    /// <summary>
    /// WVarSetting.xaml の相互作用ロジック
    /// </summary>
    public partial class WVarSetting : Window
    {
        public MainWindow WHandler;
        public WVarSetting()
        {
            InitializeComponent();
        }

        public WVarSetting(MainWindow Handler)
        {
            InitializeComponent();
            WHandler = Handler;
            this.Show();
        }

        private void Clicked(object sender, RoutedEventArgs e)
        {
            Button BCurrent = (Button)sender;

            switch(BCurrent.Name)
            {
                case "B_ok":
                    this.Close();
                    this.WHandler.W_VarSetting = null;
                    break;

                case "B_cancel":
                    break;

                default:
                    break;
            }
        }
    }
}
