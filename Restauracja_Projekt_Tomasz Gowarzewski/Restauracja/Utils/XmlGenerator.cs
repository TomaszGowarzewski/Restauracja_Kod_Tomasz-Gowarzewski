using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Linq;

namespace Restauracja
{
    class XmlGenerator
    {
        

        internal static void SaveOrderToXml(ObservableCollection<Dish> listOfDishes, int suma, string informationToOrder)
        {

            XDocument doc;
            ObservableCollection<XElement> OrderList = new ObservableCollection<XElement>();
            foreach(Dish danie in listOfDishes)
            {
                XElement el = new XElement("Danie", new XElement("Nazwa",danie.DishName), new XElement("Cena",danie.Price));
                OrderList.Add(el);
            }
            XElement data = new XElement("Data",new XElement(new XElement( "Data", DateTime.Now.ToShortDateString())),new XElement("Godzina",DateTime.Now.ToShortTimeString()));
            XElement zam = new XElement("Zamowienie", new XElement("Dania", OrderList), new XElement("Data", data), new XElement("Suma", suma),new XElement("InformacjeDoZamowienia",informationToOrder));
            XElement root = new XElement("Zamowienia", new XElement(zam));

            if (File.Exists("History.xml"))
            {
                doc = XDocument.Load("History.xml");
                doc.Element("Zamowienia").Add(zam);
            }
            else
            {
                doc = new XDocument();
                doc.Add(root);

            }
            doc.Save("History.xml");
        }
    }
}
