using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using Test.Data;
using Test.Entities;

namespace Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Repository repository;
        public MainWindow()
        {
            InitializeComponent();
            repository  = new Repository();
        }

        private void TextBox_TextChangedAsync(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (search_text.Text.Length > 2)
                {
                    //var entity = repository.CreateAsycn(product);
                    IList<Product> qwerty = repository.GetAll(p => p.Barcode.ToString().ToLower().Contains(search_text.Text.ToLower())).ToList();

                    data.ItemsSource = qwerty;
                    data.Items.Refresh();
                }
                else
                {
                    data.ItemsSource = null;
                    data.Items.Refresh();
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 15000; i++)
            {
                Product product = new Product()
                {
                    Name = "Product",
                };

                var entity = repository.CreateAsycn(product);

                IList<Product> qwerty = repository.GetAll().ToList();

                data.ItemsSource = qwerty;
                data.Items.Refresh();
            }
        }
    }
}
