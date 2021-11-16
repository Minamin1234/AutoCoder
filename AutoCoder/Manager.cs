using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Collections.ObjectModel;

namespace AutoCoder
{
    public static class Manager
    {
        public static void AddCtnt(ref ACObject[] arry,ACObject addctnt)
        {
            Array.Resize(ref arry, arry.Length + 1);
            arry.Append(addctnt);
        }

        public static ObservableCollection<ACObject> GetItmSrc(ACObject[] arry)
        {
            var itmsrc = new ObservableCollection<ACObject>();
            foreach(var itm in arry)
            {
                itmsrc.Add(itm);
            }
            return itmsrc;
        }

        public static bool RemvCtnt(ref ACObject[] arry,ACObject remvItm)
        {
            foreach(var itm in arry)
            {
                if(itm == remvItm)
                {
                    int i = 0;
                    ACObject[] nwarry = new ACObject[0];
                    foreach(var nwitm in arry)
                    {
                        if (nwitm == itm) continue;
                        Array.Resize(ref nwarry, nwarry.Length + 1);
                        nwarry.Append(nwitm);
                    }
                    arry = nwarry;
                }
                return true;
            }
            return false;
        }
        public static bool RemvCtnt(ref ACObject[] arry,int remvIdx)
        {
            if (remvIdx > arry.Length - 1) return false;
            arry[remvIdx] = null;
            ACObject[] nwarry = new ACObject[0];
            foreach(var itm in arry)
            {
                if (itm == null) continue;
                Array.Resize(ref nwarry, nwarry.Length + 1);
                nwarry.Append(itm);
            }
            arry = nwarry;
            return true;
        }
    }
}
