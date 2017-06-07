using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFMMVMDataGrid
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<MissingDataModel> missingList;
                
        public List<MissingDataModel> MissingList
        {
            get
            {
                return GetList();
            }

            set
            {
                if (value == this.missingList)
                {
                    return;
                }

                this.missingList = value;
                this.OnPropertyChanged();
                this.OnPropertyChanged(nameof(this.MissingList));
            }
        }
        

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<MissingDataModel> GetList()
        {
            var list = new List<MissingDataModel>();

            var md1 = new MissingDataModel()
            {
                ZNumber = 1,
                CashRegisterSerialNumber = "Serial1",
                DepartmentTotal = 0,
                DepartmentTotalVat = 0
            };

            var md2 = new MissingDataModel()
            {
                ZNumber = 2,
                CashRegisterSerialNumber = "Serial2",
                DepartmentTotal = 0,
                DepartmentTotalVat = 0
            };

            list.Add(md1);
            list.Add(md2);

            return list;
        }
    }

    public class MissingDataModel
    {
        public int ZNumber { get; set; }
        public string CashRegisterSerialNumber { get; set; }
        public decimal DepartmentTotal { get; set; }
        public decimal DepartmentTotalVat { get; set; }
    }
}
