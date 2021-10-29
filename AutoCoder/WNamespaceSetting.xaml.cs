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
    /// WNamespaceSetting.xaml の相互作用ロジック
    /// </summary>
    public partial class WNamespaceSetting : Window
    {
        public MainWindow WHandler;
        public WNamespaceSetting()
        {
            InitializeComponent();
        }

        public bool SetNmspBX()
        {
            var NewNmspBX = new NamespaceBox();
            NewNmspBX.Name = this.TB_name.Text;
            var NmspMng = this.WHandler.NmspMng;
            if (NmspMng.AddNamespace(NewNmspBX)) return true;
            else return false;
        }
    }
}
