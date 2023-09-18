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

namespace WpfApp13
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Product> employers = new List<Product>();
        int ind = -1;
        public MainWindow()
        {
            InitializeComponent();
            employers.Add(new Product("Хлеб", 20, "вкусный свежий белый"));
            all.ItemsSource = employers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Product emp = new Product();
            emp.name = tb3.Text;
            bool t = true;
            for (int i = 0; i < tb4.Text.Length; i++)
                if (tb4.Text[i] != 46 || tb4.Text[i] < 48 || tb4.Text[i] > 57)
                {
                    MessageBox.Show("EROR PRICE");
                    t = false;
                    break;
                }
            if (t) {
                emp.price = Int32.Parse(tb4.Text);
                emp.adress = tb5.Text;
                employers.Add(emp);
                all.Items.Refresh(); 
            }
        }
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            all.Focus();
            if (ind != -1)
            {
                Product emp = new Product();
                emp.name = tb3.Text;
                bool t = true;
                for (int i = 0; i < tb4.Text.Length; i++)
                    if (tb4.Text[i] < 48 || tb4.Text[i] > 57)
                    {
                        MessageBox.Show("EROR PRICE");
                        t = false;
                        break;
                    }
                if (t)
                {
                    emp.price = Int32.Parse(tb4.Text);
                    emp.adress = tb5.Text;
                    employers[ind] = emp;
                    all.Items.Refresh();
                }
            }
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            all.Focus();
            if (all.SelectedIndex != -1)
            {
                employers.RemoveAt(all.SelectedIndex);
                all.Items.Refresh();
            }
        }
        public class Product
        {
            public Product()
            {

            }
            public Product(string a, int b, string c)
            {
                name = a;
                price = b;
                adress = c;
            }
            public string name;
            public int price;
            public string adress;
            public override string ToString() { return $"{name} {price} грн {adress}"; }
        }

        private void all_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (all.SelectedIndex != -1)
            {
                ind=all.SelectedIndex;
                tb3.Text = employers[all.SelectedIndex].name;
                tb4.Text = employers[all.SelectedIndex].price.ToString();
                tb5.Text = employers[all.SelectedIndex].adress;
            }
        }

    }
}
