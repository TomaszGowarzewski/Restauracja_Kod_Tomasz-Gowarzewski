using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restauracja
{
    class HistoryViewModel : INotifyPropertyChanged
    {


        ObservableCollection<Order> orders;

        public ObservableCollection<Order> Orders
        {
            get
            {
                return orders;
            }

            set
            {
                orders = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Orders"));
                }
            }
        }

       public HistoryViewModel()
        {
            DataLoader loader = new DataLoader();
            Orders = loader.LoadOrders();
        }

        
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
