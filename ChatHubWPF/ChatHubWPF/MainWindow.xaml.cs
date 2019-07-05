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

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\arenz\source\repos\ChatHubWPF\ChatHubWPF\Data\Users.mdf;Integrated Security=True"))
            {
                Window1 ProgramWindow = new Window1(TextBox1.Text);
                ProgramWindow.Show();
                SqlCommand command = new SqlCommand();
                command.Connection = con;
                con.Open();
                command.CommandText = "insert into [Table](Name,Username) values('" + TextBox1.Text + "','" + TextBox1.Text + "')";
                command.ExecuteNonQuery();
                con.Close();
            }
            this.Close();
        }

        private void RadButton_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You are registered.", "Congratulations!!!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.Yes, MessageBoxOptions.DefaultDesktopOnly);
        }

        private void TextBox1_MouseEnter(object sender, MouseEventArgs e)
        {
            if (TextBox1.Text == "Username") TextBox1.Text = "";
        }

        private void TextBox1_MouseLeave(object sender, MouseEventArgs e)
        {
            if (TextBox1.Text == "") TextBox1.Text = "Username";
        }

        private void PasswordBox1_MouseEnter(object sender, MouseEventArgs e)
        {
            if (PasswordBox1.Password == "password") PasswordBox1.Password = "";
        }

        private void PasswordBox1_MouseLeave(object sender, MouseEventArgs e)
        {
            if (PasswordBox1.Password == "") PasswordBox1.Password = "password";
        }

        private void TextBox2_MouseEnter(object sender, MouseEventArgs e)
        {
            if (TextBox2.Text == "Name") TextBox2.Text = "";
        }

        private void TextBox2_MouseLeave(object sender, MouseEventArgs e)
        {
            if (TextBox2.Text == "") TextBox2.Text = "Name";
        }

        private void TextBox3_MouseEnter(object sender, MouseEventArgs e)
        {
            if (TextBox3.Text == "Email") TextBox3.Text = "";
        }

        private void TextBox3_MouseLeave(object sender, MouseEventArgs e)
        {
            if (TextBox3.Text == "") TextBox3.Text = "Email";
        }

        private void TextBox4_MouseEnter(object sender, MouseEventArgs e)
        {
            if (TextBox4.Text == "Username") TextBox4.Text = "";
        }

        private void TextBox4_MouseLeave(object sender, MouseEventArgs e)
        {
            if (TextBox4.Text == "") TextBox4.Text = "Username";
        }

        private void PasswordBox2_MouseEnter(object sender, MouseEventArgs e)
        {
            if (PasswordBox2.Password == "password") PasswordBox2.Password = "";
        }

        private void PasswordBox2_MouseLeave(object sender, MouseEventArgs e)
        {
            if (PasswordBox2.Password == "") PasswordBox2.Password = "password";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //RaiseEvent(new RoutedEventArgs());
        }
    }
}