using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFMMVMDataGrid
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            this.MissingList = new ObservableCollection<MissingDataModel>
            {
                new MissingDataModel()
                {
                    ZNumber = 1,
                    CashRegisterSerialNumber = "Serial1",
                    DepartmentTotal = 0,
                    DepartmentTotalVat = 0
                },

                new MissingDataModel()
                {
                    ZNumber = 2,
                    CashRegisterSerialNumber = "Serial2",
                    DepartmentTotal = 0,
                    DepartmentTotalVat = 0
                },
            };

            this.AddItemToCollection = new MyCommand(x => this.MissingList.Add(new MissingDataModel
            {
                ZNumber  = 3,
                CashRegisterSerialNumber = "Added Item",
                DepartmentTotal = 1, 
                DepartmentTotalVat = 1
            }));
            //this.AddNewItemCommand = new RelayCommand(_ => this.MissingList.Add(new ...));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<MissingDataModel> MissingList { get; }
        public ICommand AddItemToCollection { get; }
        


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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


