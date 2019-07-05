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
using ChatHubWPF.ServiceChat;
using System.Threading;

namespace ChatHubWPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window, ServiceChat.IServiceChatCallback
    {
        public string username;
        int id;
        ServiceChat.ServiceChatClient client;
        public Window1(string t1Text)
        {
            InitializeComponent();
            username = t1Text;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
            id = client.Connect(username);
            MessageBox.Show("Welcome, " + username + ", you are online now. Enjoy it.", "Congratulations!!!");
            UpdateRadGridViewData();
        }
        public void MsgCallback(string msg)
        {
            ChatMessages.Items.Add(msg);
            UpdateRadGridViewData();
        }

        public void UpdateRadGridViewData()
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
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\arenz\source\repos\ChatHubWPF\ChatHubWPF\Data\Users.mdf;Integrated Security=True"))
            {
                con.Open();
                SqlCommand command = new SqlCommand("delete from [Table] where Name='" + username + "'", con);
                command.ExecuteNonQuery();
                con.Close();
            }
            client.Disconnect(id);
            Environment.Exit(0);
        }
        private void ButtonMinimize_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateRadGridViewData();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            client.Disconnect(id);
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\arenz\source\repos\ChatHubWPF\ChatHubWPF\Data\Users.mdf;Integrated Security=True"))
            {
                con.Open();
                SqlCommand command = new SqlCommand("delete from [Table] where Name='"+username+"'", con);
                command.ExecuteNonQuery();
                con.Close();
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                client.SendMsg(MessageTextbox.Text, id);
                MessageTextbox.Text = "";
            }
        }
    }
}