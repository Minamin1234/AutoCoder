using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Collections.ObjectModel;

namespace AutoCoder
{
    public class Manager
    {
        public MainWindow MWHandler;
        public Window MNGRWindow;
        public ACObject[] Contents = { new ACObject() };

        public Manager(MainWindow mwHandler)
        {
            this.MWHandler = mwHandler;
        }

        public ObservableCollection<ACObject> GetItmSrc()
        {
            var itmsrc = new ObservableCollection<ACObject>();
            foreach(var itm in this.Contents)
            {
                itmsrc.Add(itm);
            }
            return itmsrc;
        }

        public void AddCtnt(ACObject additm)
        {
            Array.Resize(ref this.Contents, this.Contents.Length + 1);
            this.Contents.Append(additm);
        }

        public bool RemvCtnt(ACObject remvItm)
        {
            foreach(var itm in this.Contents)
            {
                if (itm == remvItm)
                {
                    ACObject[] nwarray = { new ACObject() };
                    foreach(var nwitm in this.Contents)
                    {
                        if (nwitm == remvItm) continue;
                        Array.Resize(ref nwarray, nwarray.Length + 1);
                        nwarray.Append(nwitm);
                    }
                    this.Contents = nwarray;
                    return true;
                }
            }
            return false;
        }
    }
}
