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
using System.Windows.Shapes;

using System.Collections.ObjectModel;

namespace AutoCoder
{
    public interface IDataEditing
    {
        void SetSubWindow(Window nwindow);
        void ClearSubWindow();
        void CommitNewData(ACObject newData);
        void CommitEditData(ACObject editData);
    }

    public interface IMemo<T>
    {
        bool CommitData(EDITPROPERTY<T> editproperty);
    }
}
