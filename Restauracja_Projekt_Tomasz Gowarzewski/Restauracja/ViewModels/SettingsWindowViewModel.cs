using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Restauracja
{
    class SettingsWindowViewModel : INotifyPropertyChanged
    {
        string smtpServer;
        string emailUser;
        string emailPassword;
        int port;

        User user = new User();
        public ICommand SaveSettings { get; set; }

        public string SmtpServer
        {
            get
            {
                return smtpServer;
            }

            set
            {
                smtpServer = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SmtpServer"));
            }
        }

        public string EmailUser
        {
            get
            {
                return emailUser;
            }

            set
            {
                emailUser = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EmailUser"));
            }
        }

        public string EmailPassword
        {
            get
            {
                return emailPassword;
            }

            set
            {
                emailPassword = value;
                PropertyChanged(this,new PropertyChangedEventArgs("EmailPassword"));
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
                PropertyChanged(this, new PropertyChangedEventArgs("Port"));
            }
        }

        public SettingsWindowViewModel()
        {
            SaveSettings = new Command(Save, CanSave);
        }

        private bool CanSave(object obj)
        {
            if (EmailPassword != null && EmailUser != null && SmtpServer != null)
            {
                return true;
            }
            return false;

        }

        private void Save(object obj)
        {
            user.SMTPServer = SmtpServer;
            user.Email = EmailUser;
            user.Password = EmailPassword;
            user.Port = Port;
            SerializeSettings(user);
            MessageBox.Show("Ustawienia Zostały zapisane");
        }

        private void SerializeSettings(User user)
        {
            try
            {
                using (Stream stream = File.Open("user.bin", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream,user);
                }
            } catch(Exception ex)
            {
                MessageBox.Show("Zapis nie powiódł się");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
