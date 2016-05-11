using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Restauracja
{
    /// <summary>
    /// Interaction logic for ApplyWindow.xaml
    /// </summary>
    public partial class ApplyWindow : Window
    {
        private ObservableCollection<Dish> listaZZakupami1;
        private int suma;

         ApplyWindowViewModel viewModel;
    
        public ApplyWindow(ObservableCollection<Dish> listaZZakupami1, int suma)
        {
            this.listaZZakupami1 = listaZZakupami1;
            this.suma = suma;
            viewModel = new ApplyWindowViewModel(listaZZakupami1, suma);
            
            this.DataContext = viewModel;
            InitializeComponent();
        }
    }
}
