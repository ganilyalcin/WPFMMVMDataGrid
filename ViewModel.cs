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
                return this.missingList;
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
    }

    public class MissingDataModel
    {
        public int ZNumber { get; set; }
        public string CashRegisterSerialNumber { get; set; }
        public DateTime ZDateTime { get; set; }
        public decimal DepartmentTotal { get; set; }
        public decimal DepartmentTotalVat { get; set; }
        public decimal CashAmount { get; set; }
        public decimal CreditAmount { get; set; }
    }
}
