using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace Restauracja
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private int sum = 0;
        private Dish selectedDish;
        private Dish selectedDishFromList;
        private List<Dish> menu = new List<Dish>();
        private ObservableCollection<Dish> dishesList;
        private Service service = new Service();

        private ObservableCollection<Dish> menuPizzas = new ObservableCollection<Dish>();
        private ObservableCollection<Dish> menuMainDishes = new ObservableCollection<Dish>();
        private ObservableCollection<Dish> menuPizzaToppings = new ObservableCollection<Dish>();
        private ObservableCollection<Dish> menuMainDishToppings = new ObservableCollection<Dish>();
        private ObservableCollection<Dish> menuDrinks = new ObservableCollection<Dish>();
        private ObservableCollection<Dish> menuSoups = new ObservableCollection<Dish>();





        public ICommand AddDishToList { get; set; }
        public ICommand ApplyList { get; set; }
        public ICommand SettingsCommand { get; set; }
        public ICommand ShowHistory { get; set; }
        public ICommand RemoveDish { get; set; }
        public ICommand RemoveList { get; set; }
        public ICommand AuthorScreen { get; set; }

        public Dish SelectedDish 
        {
            get
            {
               return selectedDish;
            }

            set
            {
                selectedDish = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedDish"));
            }
        }

        public Dish SelectedDishFromList
        {
            get
            {
                return selectedDishFromList;
            }

            set
            {
                selectedDishFromList = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedDishFromList"));
            }
        }

        public List<Dish> Menu
        {
            get
            {
                return menu;
            }

            set
            {
                 menu = value;
                if (PropertyChanged != null)
                {
                      PropertyChanged(this, new PropertyChangedEventArgs("Menu"));
                }
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
                if (DishesList != null)
                {
                    dishesList = value;
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
                PropertyChanged(this, new PropertyChangedEventArgs("Sum"));
            }
        }

        public ObservableCollection<Dish> MenuPizzas
        {
            get
            {
                return menuPizzas;
            }

            set
            {
                menuPizzas = value;
                PropertyChanged(this, new PropertyChangedEventArgs("MenuPizzas"));
            }
        }

        public ObservableCollection<Dish> MenuMainDishes
        {
            get
            {
                return menuMainDishes;
            }

            set
            {
                menuMainDishes = value;
                PropertyChanged(this, new PropertyChangedEventArgs("MenuMainDishes"));
            }
        }

        public ObservableCollection<Dish> MenuPizzaToppings
        {
            get
            {
                return menuPizzaToppings;
            }

            set
            {
                menuPizzaToppings = value;
                PropertyChanged(this, new PropertyChangedEventArgs("MenuPizzaToppings"));
            }
        }

        public ObservableCollection<Dish> MenuMainDishToppings
        {
            get
            {
                return menuMainDishToppings;
            }

            set
            {
                menuMainDishToppings = value;
                PropertyChanged(this, new PropertyChangedEventArgs("MenuMainDishToppings"));
            }
        }

        public ObservableCollection<Dish> MenuDrinks
        {
            get
            {
                return menuDrinks;
            }

            set
            {
                menuDrinks = value;
                PropertyChanged(this, new PropertyChangedEventArgs("MenuDrinks"));
            }
        }

        public ObservableCollection<Dish> MenuSoups
        {
            get
            {
                return menuSoups;
            }

            set
            {
                menuSoups = value;
                PropertyChanged(this, new PropertyChangedEventArgs("MenuSoups"));
            }
        }

        public MainWindowViewModel()
        {
            dishesList = new ObservableCollection<Dish>();
            Menu = service.GetDishes();
            AddDishToList = new Command(AddDish, CanAddDish);
            ApplyList = new Command(Apply, CanApply);
            SettingsCommand = new Command(Settings, CanSettings);
            ShowHistory = new Command(Show, CanShow);
            RemoveDish = new Command(Remove, CanRemove);
            RemoveList = new Command(CleanList, CanCleanList);
            AuthorScreen = new Command(ShowAuthor, CanShowAuthor);
            LoadTypes();


        }

        private void ShowAuthor(object obj)
        {
            Views.AuthorScreen authorScreen = new Views.AuthorScreen();
            authorScreen.Show();
        }

        private bool CanShowAuthor(object obj)
        {
            return true;
        }

        private bool CanCleanList(object obj)
        {
            if (DishesList.Count !=0)
            {
                return true;
            }
            return false;
        }

        private void CleanList(object obj)
        {
            DishesList.Clear();
            Sum = 0;
        }

        private bool CanRemove(object obj)
        {
            if (DishesList.Count != 0)
            {
                return true;
            }
            return false;
        }

        private void Remove(object obj)
        {
            for (int i=0;i< DishesList.Count;i++) 
            {
                if (DishesList.ElementAt(i) == selectedDishFromList)
                {
                    Sum = Sum - DishesList.ElementAt(i).Price;
                    DishesList.RemoveAt(i);
                    break;
                }
            }
           
        }

        private void LoadTypes()
        {
            foreach(Dish dish in Menu)
            {
                switch(dish.DishType)
                {
                    case DishType.MAIN_DISHES:
                        {
                            MenuMainDishes.Add(dish);
                            break;
                        }
                    case DishType.MAIN_DISHES_TOPPINGS:
                        {
                            MenuMainDishToppings.Add(dish);
                            break;
                        }
                    case DishType.PIZZA_TOPPINGS:
                        {
                            MenuPizzaToppings.Add(dish);
                            break;
                        }
                    case DishType.PIZZA:
                        {
                            MenuPizzas.Add(dish);
                            break;
                        }
                    case DishType.SOUPS:
                        {
                            MenuSoups.Add(dish);
                            break;
                        }
                    case DishType.DRINKS:
                        {
                            MenuDrinks.Add(dish);
                            break;
                        }                                                            
                }
                    
               
            }
        }

        private bool CanShow(object obj)
        {
            return true;
        }

        private void Show(object obj)
        {
            HistoryView historyView = new HistoryView();
            historyView.Show();
        }

        private void Settings(object obj)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.Show();
        }

        private bool CanSettings(object obj)
        {
            return true;
        }

        private bool CanApply(object obj)
        {
            if (DishesList.Count != 0)
            {
                return true;
            }
            return false;
        }

        private void Apply(object obj)
        {
            ApplyWindow window = new ApplyWindow(DishesList, Sum);
            window.Show();
        }

        private bool CanAddDish(object obj)
        {
            if (SelectedDish != null)
                return true;
            return false;
        }

        private void AddDish(object obj)
        {
            DishesList.Add(SelectedDish);
            Sum = Sum + SelectedDish.Price;
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
