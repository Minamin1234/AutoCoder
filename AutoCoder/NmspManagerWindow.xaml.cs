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

using System.Collections.ObjectModel;

namespace AutoCoder
{
    /// <summary>
    /// NmspManagerWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class NmspManagerWindow : Window,IDataEditing
    {
        public WindowManager WinManager;
        public MainWindow WHander = null;
        public Window SubWindow = null;
        public SourceFile CurrentFile = null;
        public NmspManagerWindow()
        {
            InitializeComponent();
            this.Initialize();
        }
        public NmspManagerWindow(ref SourceFile TargetFile,MainWindow whandler)
        {
            InitializeComponent();
            this.Initialize();
            if (whandler != null) this.WHander = whandler;
            if (TargetFile != null) this.CurrentFile = TargetFile;
            this.Show();
            this.LoadDatas();
        }

        public bool Initialize()
        {
            this.WinManager = new WindowManager(this);
            return true;
        }

        public void LoadDatas()
        {
            var list = new ObservableCollection<Namespace>();
            foreach (var itm in this.CurrentFile.Namespaces)
            {
                list.Add(itm);
            }
            this.LB_Nmsp.ItemsSource = list;
        }

        public bool CommitData(EDITPROPERTY editproperty)
        {
            if (editproperty != null && editproperty.TargetData != null) this.LoadDatas();
            this.LoadDatas();
            return true;
        }

        private void WClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.WHander.SubWindow = null;
        }

        private void BClicked(object sender, RoutedEventArgs e)
        {
            var CurentButton = (Button)sender;
            if(CurentButton.Name == B_Add.Name)
            {
                var editpropty = new EDITPROPERTY(this.CurrentFile.Namespaces);
                if (this.WinManager.IsEditing != true) 
                    this.WinManager.OpenSetSubWindow(new CreateNmspWindow(this,editpropty));
            }
        }
    }
}
