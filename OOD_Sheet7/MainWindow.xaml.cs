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

        private void UI_Ex2_Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from customers in db.Customers
                        where customers.Country == "Italy"
                        //group customers by customers.Country into italyCustomers
                        //orderby italyCustomers.Key.Count()
                        select customers;
            //{
            //    Orders = " ",
            //    CustomerDemographics = " ",
            //    CustomerID = customers  
            //};

            UI_Ex2_Listbox.ItemsSource = query.ToList();
        }

        private void UI_Ex3_Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from products in db.Products
                        where (products.UnitsInStock - products.UnitsOnOrder > 0)
                        select new
                        {
                            Product = products.ProductName,
                            Available = products.UnitsInStock - products.UnitsOnOrder
                        };

            UI_Ex3_Listbox.ItemsSource = query.ToList();
        }

        private void UI_Ex4_Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from disProducts in db.Order_Details
                        orderby disProducts.Product.ProductName
                        where disProducts.Discount > 0
                        select new
                        {
                            ProductName = disProducts.Product.ProductName,
                            DiscountGiven = disProducts.Discount,
                            OrderID = disProducts.OrderID
                        };

            UI_Ex4_Listbox.ItemsSource = query.ToList();
        }

        private void UI_Ex5_Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from items in db.Orders
                        select items.Freight;

            UI_Ex5_TextBlock.Text = string.Format("The total value of freight for all for all orders is {0:C}", query.Sum());
        }
    }
}
