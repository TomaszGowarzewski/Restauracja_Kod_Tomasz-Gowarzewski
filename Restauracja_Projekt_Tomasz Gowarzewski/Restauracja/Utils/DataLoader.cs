using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Linq;

namespace Restauracja
{
   public class DataLoader
    {      
        public DataLoader()
        {
            
        }

        public List<Dish> LoadXML()
        {

            if (!File.Exists("MenuRestauracji.xml"))
            {               
                return new List<Dish>();
            }
            else
            {           
               XElement doc = XElement.Load("MenuRestauracji.xml");
               List<Dish> dishesList = new List<Dish>();
               int id = 1;
               IEnumerable<XElement> nodes = doc.Elements();
               foreach (XElement node in nodes)
               {
                   IEnumerable<XElement> _nodes = node.Elements();
                   foreach (XElement node1 in _nodes)
                   {
                       Dish dish = new Dish();
                       dish.DishType = SprawdzTyp(node1.Parent.Name.ToString());
                       IEnumerable<XElement> _nodes1 = node1.Elements();
                       dish.DishID = id;
                       dish.PictureID = id;
                       dish.DishName = _nodes1.ElementAt(0).Value;
                       dish.DishDescription = _nodes1.ElementAt(2).Value;
                       dish.Price = int.Parse(_nodes1.ElementAt(1).Value);
                       dishesList.Add(dish);
                       id++;
                   }
               }
               return dishesList;
           }
        }

        internal ObservableCollection<Order> LoadOrders()
        {
            ObservableCollection<Order> orders = new ObservableCollection<Order>();
            Order order;

            try
            {
                if (!File.Exists("History.xml"))
                {
                    File.Create("History.xml");
                }
                XElement doc = XElement.Load("History.xml");
                IEnumerable<XElement> _orders = doc.Elements();
                foreach (XElement _order in _orders)
                {
                    order = new Order();
                    IEnumerable<XElement> OrderPoints = _order.Elements();
                    foreach (XElement _dishes in OrderPoints.ElementAt(0).Elements())
                    {
                        IEnumerable<XElement> dishes = _dishes.Elements();
                        Dish dish = new Dish();
                        dish.DishName = dishes.ElementAt(0).Value;
                        dish.Price = int.Parse(dishes.ElementAt(1).Value);
                        order.Dishes.Add(dish);
                    }
                    foreach (XElement _date in OrderPoints.ElementAt(1).Elements())
                    {
                        IEnumerable<XElement> date = _date.Elements();
                        order.Date = date.ElementAt(0).Value;
                        order.Hour = date.ElementAt(1).Value;
                    }

                    order.Sum = int.Parse(OrderPoints.ElementAt(2).Value);
                    order.Information = OrderPoints.ElementAt(3).Value;
                    orders.Add(order);

                }
                return orders;
            }
            catch (Exception ex)
            {
                return new ObservableCollection<Order>();

            }


        }

        internal static User LoadUser()
        {
            try
            {
                using (Stream stream = File.Open("user.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    var user = (User)bin.Deserialize(stream);
                    return user;
                }
            }
            catch (Exception ex)
            {
                return new User();

            }

        }
        

        private DishType SprawdzTyp(string v)
        {
            switch (v)
            {
                case "Pizze":
                    {
                        return DishType.PIZZA;                        
                    }
                case "DodatkiDoPizzy":
                    {
                        return DishType.PIZZA_TOPPINGS;                      
                    }
                case "DaniaGlowne":
                    {
                        return DishType.MAIN_DISHES;                       
                    }
                case "DodatkiDoDanGlownych":
                    {
                        return DishType.MAIN_DISHES_TOPPINGS;                       
                    }
                case "Zupy":
                    {
                        return DishType.SOUPS;                       
                    }
                case "Napoje":
                    {
                         return DishType.DRINKS;                        
                    }
                default:
                    return DishType.UNKNOWN;
            }
        }
    }
}
