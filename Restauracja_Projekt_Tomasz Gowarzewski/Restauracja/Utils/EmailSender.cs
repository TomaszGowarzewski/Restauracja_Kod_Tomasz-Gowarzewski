using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows;

namespace Restauracja
{
    class EmailSender
    {

        internal static void SendOrderToMail(ObservableCollection<Dish> dishesList, User user, int suma, string informationToOrder,string DestEmail,bool status)
        {
            string email = "";
            string List = FoodListing(dishesList);
            if (informationToOrder == null)
            {
                informationToOrder = "Brak";
            }
            email = "Dania:" + Environment.NewLine + List
                + Environment.NewLine + "Informacje do zamówienia: "+ Environment.NewLine+informationToOrder+
                Environment.NewLine + Environment.NewLine + "Suma: " + suma + " zł" +
                Environment.NewLine + Environment.NewLine + "Dziękujemy za złożenie zamowienia i życzymy smacznego";

                       
                MailMessage mail = new MailMessage(user.Email, DestEmail, "Zamowienie", email);
                SmtpClient client = new SmtpClient(user.SMTPServer);
            if (user.Port == 0)
            {
                client.Port = 587;

            }
            else
                client.Port = user.Port;
                client.Credentials = new System.Net.NetworkCredential(user.Email, user.Password);
                client.EnableSsl = true;
                client.Send(mail);
                status = true;                                                                
        }

        private static string FoodListing(ObservableCollection<Dish> dishesList)
        {
            string list = "";
            foreach (Dish dish in dishesList) 
            {
                list = list + dish.DishName + " "+ dish.Price + " zł" + Environment.NewLine;
            }
            return list;
                
        }
    }
}
