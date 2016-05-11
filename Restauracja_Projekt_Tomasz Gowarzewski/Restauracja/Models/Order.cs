using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restauracja
{
    class Order : INotifyPropertyChanged
    {
        ObservableCollection<Dish> dishes;
        int sum;
        string date;
        string hour;
        string information;

        public Order(ObservableCollection<Dish> dishes,int sum,string date, string hour,string information)
        {
            this.dishes = dishes;
            this.sum = sum;
            this.date = date;
            this.information = information;
            this.Hour = hour;
        }

        public Order()
        {
            dishes = new ObservableCollection<Dish>();

        }

        public ObservableCollection<Dish> Dishes
        {
            get
            {
                return dishes;
            }

            set
            {
                dishes = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Dishes"));
                }
            }
        }

        public int Sum
        {
            get
            {
                return sum;
            }

            set
            {
                sum = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Sum"));
                }
            }
        }

        public string Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Date"));
                }
            }
        }

        public string Information
        {
            get
            {
                return information;
            }

            set
            {
                information = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Information"));
                }
            }
        }

        public string Hour
        {
            get
            {
                return hour;
            }

            set
            {
                hour = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Hour"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
