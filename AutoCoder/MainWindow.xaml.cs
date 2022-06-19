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

namespace AutoCoder
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MArg arg1 = new MArg();
            arg1.SetArgName("x");
            arg1.SetType(E_TYPE.MINT);
            arg1.AttatchValue("10");
            MArg arg2 = new MArg();
            arg2.SetArgName("y");
            arg2.SetType(E_TYPE.MINT);
            arg2.AttatchValue("20");

            MExec exec = new MExec();
            exec.AddArg(arg1);
            exec.AddArg(arg2);
            Console.WriteLine(exec.Generate_CallExec());
        }
    }
}
