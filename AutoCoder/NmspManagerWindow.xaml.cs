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
        public SourceFile CurrentFile = null;
        protected Window SubWindow = null;
        public NmspManagerWindow()
        {
            InitializeComponent();
            this.Initialize();
        }
        /// <summary>
        /// 管理用ウィンドウを表示するには参照対象のソースファイルを渡し、
        /// このウィンドウを所有するメインウィンドウを指定します。
        /// </summary>
        /// <param name="TargetFile">参照対象のソースファイルクラス</param>
        /// <param name="whandler">このウィンドウを所有するメインウィンドウ</param>
        /// <exception cref="ArgumentNullException"></exception>
        public NmspManagerWindow(SourceFile TargetFile,MainWindow whandler)
        {
            InitializeComponent();
            if (TargetFile == null || whandler == null) throw new ArgumentNullException();
            this.WHander = whandler;
            this.CurrentFile = TargetFile;
            this.Initialize();
        }

        void IDataEditing.SetSubWindow(Window nwindow)
        {
            if(nwindow == null) throw new ArgumentNullException();
            if (this.SubWindow == nwindow) return;
            this.SubWindow = nwindow;
            this.SubWindow.Show();
        }

        void IDataEditing.ClearSubWindow()
        {
            this.SubWindow = null;
        }

        void IDataEditing.CommitNewData(ACObject newData)
        {
            var cnewdata = (Namespace)newData;
            if (cnewdata == null) throw new ArgumentNullException();
            this.CurrentFile.Namespaces.Add(cnewdata);
        }

        void IDataEditing.CommitEditData(ACObject editData)
        {
            var ceditdata = (Namespace)editData;
            if (ceditdata == null) throw new ArgumentNullException();
        }

        public bool Initialize()
        {
            this.WinManager = new WindowManager(this);
            this.CurrentFile = this.WHander.CurrentFile;
            var list = new ObservableCollection<Namespace>(this.CurrentFile.Namespaces);
            this.LB_Nmsp.ItemsSource = list;
            return true;
        }

        /// <summary>
        /// 新規作成用に編集ウィンドウを開きます。
        /// </summary>
        /// <exception cref="Error">ウィンドウ表示時に何かしらのエラーを返します。</exception>
        public void OpenCreateWindow()
        {
            if (this.SubWindow != null) throw new Error("既にウィンドウを開かれています。");
        }
        /// <summary>
        /// 編集用にウィンドウを開きます。
        /// </summary>
        /// <param name="target">編集対象のインデックス</param>
        public void OpenCreateWindow(int target)
        {
            if (target == -1) return;
            if (this.CurrentFile.Namespaces == null) throw new Error("CurrentFile.Namespacesがnullでした");
        }

        /// <summary>
        /// リストアイテム更新を反映させるために、リストアイテムに再代入します。
        /// </summary>
        public void FetchListData()
        {
        }

        /// <summary>
        /// このウィンドウが閉じられるとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.WHander.ClearSubWindow();
        }

        private void BClicked(object sender, RoutedEventArgs e)
        {
            var CurrentButton = (Button)sender;
            if(CurrentButton.Name == B_Add.Name)
            {
            }
            else if(CurrentButton.Name == B_Edit.Name)
            {
            }
            else if(CurrentButton.Name == B_Delete.Name)
            {
                this.CurrentFile.Namespaces.RemoveAt(this.LB_Nmsp.SelectedIndex);
            }
            else if(CurrentButton.Name == B_OK.Name)
            {
                this.Close();
            }
        }
    }
}
