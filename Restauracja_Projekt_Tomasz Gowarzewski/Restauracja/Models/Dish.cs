using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Restauracja
{
   public class Dish : INotifyPropertyChanged
    {
        private int sum = 0;
        private int dishID;
        private string dishName;
        private int price;
        private string dishDescription;
        private int pictureID;
        private DishType dishType;

        public int Sum
        {
            get
            {
                return sum;
            }

            set
            {
                sum = value;
                RaisePropertyChanged("Sum");
            }
        }

        public int DishID
        {
            get
            {
                return dishID;
            }

            set
            {
                dishID = value;
                RaisePropertyChanged("DishID");
            }
        }

        public string DishName
        {
            get
            {
                return dishName;
            }

            set
            {
                dishName = value;
                RaisePropertyChanged("DishName");
            }
        }

        public int Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
                RaisePropertyChanged("Price");
            }
        }

        public string DishDescription
        {
            get
            {
                return dishDescription;
            }

            set
            {
                dishDescription = value;
                RaisePropertyChanged("DishDescription");
            }
        }

        public int PictureID
        {
            get
            {
                return pictureID;
            }

            set
            {
                pictureID = value;
                RaisePropertyChanged("PictureID");
            }
        }

        public DishType DishType
        {
            get
            {
                return dishType;
            }

            set
            {
                dishType = value;
                RaisePropertyChanged("DishType");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged !=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public enum DishType
    {
        PIZZA = 0,
        PIZZA_TOPPINGS = 1,
        MAIN_DISHES = 3,
        MAIN_DISHES_TOPPINGS = 4,
        SOUPS = 5,
        DRINKS= 6,
        UNKNOWN = 7
    }
}
