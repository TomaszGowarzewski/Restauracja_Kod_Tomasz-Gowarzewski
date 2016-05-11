using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Restauracja
{
    

    public  class Service :INotifyPropertyChanged
    {
        private  List<Dish> dishesList;
        DataLoader loader = new DataLoader();
   
                    
        public List<Dish> GetDishes()
        {
            if (dishesList == null)
            {
                dishesList = loader.LoadXML();
            }
            return dishesList;
        }

        public event PropertyChangedEventHandler PropertyChanged;
   
    }
}
