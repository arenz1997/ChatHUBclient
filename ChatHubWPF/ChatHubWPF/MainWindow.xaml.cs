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
using System.Data.SqlClient;

namespace ChatHubWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void RadButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Your username is: " + TextBox1.Text + ", and password is: " + PasswordBox1.Password, "Congratulations!!!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.Yes, MessageBoxOptions.DefaultDesktopOnly);

            //using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\arenz\source\repos\ChatHubWPF\ChatHubWPF\Data\Users.mdf;Integrated Security=True"))
            //{
            //    SqlCommand command = new SqlCommand();
            //    command.Connection = con;
            //    con.Open();
            //    command.CommandText = "insert into [Table](Name,Username) values('" + TextBox1.Text + "','" + TextBox1.Text + "')";
            //    command.ExecuteNonQuery();
            //    con.Close();
            //}

            Window1 ProgramWindow = new Window1(TextBox1.Text);
            ProgramWindow.Show();
            this.Hide();
        }

        private void RadButton_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You are registered.", "Congratulations!!!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.Yes, MessageBoxOptions.DefaultDesktopOnly);
        }
    }
}