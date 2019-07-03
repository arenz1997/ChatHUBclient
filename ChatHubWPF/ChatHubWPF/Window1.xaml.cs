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
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;

namespace ChatHubWPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        string t1;
        public Window1(string t1Text)
        {
            InitializeComponent();
            t1 = t1Text;
        }

        private void UpdateRadGridViewData()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\arenz\source\repos\ChatHubWPF\ChatHubWPF\Data\Users.mdf;Integrated Security=True"))
            {
                SqlCommand command = new SqlCommand("select Name,Username from [Table]", con);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable("UsersTable");
                dataAdapter.Fill(dataTable);
                RadGridView.ItemsSource = dataTable;
            }
        }
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }
        private void ButtonMinimize_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Welcome, " + t1 + ", you are online now. Enjoy it.", "Congratulations!!!");
            //UpdateRadGridViewData();           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateRadGridViewData();
        }
    }
}