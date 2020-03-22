using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOD_Sheet7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NORTHWNDEntities db = new NORTHWNDEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        // Exercise 1
        private void UI_Ex1_Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from customer in db.Customers
                        group customer by customer.Country into customerGroup
                        orderby customerGroup.Count() descending
                        select new
                        {
                            Country = customerGroup.Key,
                            Count =  customerGroup.Count()
                        };

            UI_Ex1_Listbox.ItemsSource = query.ToList();
        }
    }
}
