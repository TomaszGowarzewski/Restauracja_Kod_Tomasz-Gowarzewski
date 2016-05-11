using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restauracja
{
    [Serializable]
   public class User : INotifyPropertyChanged
    {
        private string sMTPserver;
        private string email;
        private string password;
        private int port;




        public event PropertyChangedEventHandler PropertyChanged;

        public string SMTPServer
        {
            get
            {
                return sMTPserver;
            }

            set
            {
                sMTPserver = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SMTPServer"));
                }
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
                if (PropertyChanged !=null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Email"));
                }
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Password"));
                }
            }
        }

        public int Port
        {
            get
            {
                return port;
            }

            set
            {
                port = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Port"));
                }
            }
        }
    }
}
