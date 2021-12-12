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
    /// CreateNmspWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class CreateNmspWindow : Window
    {
        public Window WHandler = null;
        public EDITPROPERTY EditProperty = null;

        public CreateNmspWindow(Window whandler, EDITPROPERTY editproperty)
        {
            InitializeComponent();
            this.WHandler = whandler;
            if (editproperty == null) throw new ArgumentNullException();
            else this.EditProperty = editproperty;
            this.Initialize();
            
        }
        public void Initialize()
        {

        }

        private void BClicked(object sender, RoutedEventArgs e)
        {
            var currentbutton = (Button)sender;

            if(currentbutton.Name == B_OK.Name)
            {
            }
        }
    }
}


