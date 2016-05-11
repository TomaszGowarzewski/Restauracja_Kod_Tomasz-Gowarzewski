using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Restauracja
{
  public  class ApplyWindowViewModel : INotifyPropertyChanged
    {
        ObservableCollection<Dish> dishesList;
        int sum;
        string destEmail = "";
        DataLoader loader = new DataLoader();
        string informationToOrder;
        bool status;
        public ICommand SendOrder { get; set; }


        public  ApplyWindowViewModel(ObservableCollection<Dish> dishesList,int _sum)
        {
            DishesList = dishesList;
            Sum = _sum;
            SendOrder = new Command(Send, CanSend);
            
        }

        private bool CanSend(object obj)
        {                             
                return true;                       
        }

        private void Send(object obj)
        {
            status = true;
             if (DestEmail.Length == 0)
            {
                MessageBox.Show("Proszę podać e-mail");
            }
            else if ((!Regex.IsMatch(DestEmail, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$")))
            {
                MessageBox.Show("Proszę podać prawidłowy format e-mail");
            }
          
            else
            {
                Task task = new Task(() => DoWork());
                task.Start();
                WaitWindow window = new WaitWindow();
                window.Show();
                while (task.Status == TaskStatus.Running)
                {
                    Thread.Sleep(10);
                }
                window.Close();
                if (status == true)
                {
                    MessageBox.Show("Dziękujemy Serdecznie za złożenie zamowienia \nŻyczymy Smacznego");
                }
            }
        }

        private void DoWork()
        {

            User user = DataLoader.LoadUser();
            try
            {
                EmailSender.SendOrderToMail(DishesList, user, Sum, InformationToOrder, DestEmail,status);         
                XmlGenerator.SaveOrderToXml(DishesList, Sum, InformationToOrder);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd przy wysyłaniu,sprawdź połączenie z internetem lub ustawienia SMTP(Program->Ustawienia SMTP) ");
                status = false;
            }
            
        }

        public ObservableCollection<Dish> DishesList
        {
            get
            {
                return dishesList;
            }

            set
            {
                dishesList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("DishesList"));
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

        public string DestEmail
        {
            get
            {
                return destEmail;
            }

            set
            {
                destEmail = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("DestEmail"));
                }
            }
        }

        public string InformationToOrder
        {
            get
            {
                return informationToOrder;
            }

            set
            {
                informationToOrder = value;
                PropertyChanged(this, new PropertyChangedEventArgs("InformationToOrder"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
