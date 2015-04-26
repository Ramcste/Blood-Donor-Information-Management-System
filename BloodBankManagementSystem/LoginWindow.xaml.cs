using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;

namespace BloodBankManagementSystem
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow
    {
        public static SqlConnection Conn;
        
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_OnClick(object sender, RoutedEventArgs e)
        {

             if (UsertypeComboBox.Text == "Normal")
            {
                NameTextBox.Text = string.Empty;
                AdminPasswordBox.Password = string.Empty;
              
                UserWindow user=new UserWindow();
                Close();
                user.ShowDialog();
            }

            else if (NameTextBox.Text == "" || AdminPasswordBox.Password == ""||UsertypeComboBox.Text=="")
            {
                MessageBox.Show("Fill up all the boxes!!");
            }

            else if (!Regex.Match(NameTextBox.Text,@"^([A-Z][a-z]+||[A-Z][a-z]+\s[A-Z][a-z]+||[A-Z][a-z]+\s[A-Z][a-z]+\s[A-Z][a-z]+)$").Success)
            {
                MessageBox.Show("Error in Name Format","Message",MessageBoxButton.OK,MessageBoxImage.Error);


            }


            else if (!Regex.Match(AdminPasswordBox.Password, "^[a-z0-9_-]{6,18}$").Success)
            {
                MessageBox.Show("Password must be the combination of lowercase letters and numbers");
            }

            else if (UsertypeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Select User type!!");
            }
            
           


            else if (UsertypeComboBox.Text == "Admin")
            {
                string name = NameTextBox.Text;
                string password = AdminPasswordBox.Password;

                Conn = DatabaseConnection.GetConnection();

                if (Conn.State.ToString() == "closed")
                {
                    Conn.Open();
                }

                string query = string.Format("select Name,Password from admin where Name='"+name+"' and Password='"+password+"'");

                SqlCommand cmd=new SqlCommand(query,Conn);

                SqlDataReader reader = cmd.ExecuteReader();
                int count = 0;

                while (reader.Read())
                {
                    count= count+1;
                }

                if (count == 1)
                {
                    
                    MainWindow window=new MainWindow();
                    Close();
                    window.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Error in Name or Password or both");
                }


            }
            
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
             NameTextBox.Text=string.Empty;
             AdminPasswordBox.Password=string.Empty;

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            EventList();
        }

        private void  EventList()
        {
           
            Conn = DatabaseConnection.GetConnection();

            if (Conn.State.ToString() == "closed")
            {
                Conn.Open();
            }

            string query = string.Format("select Name,Place,date from event");
        
           SqlCommand cmd=new SqlCommand(query,Conn);

            SqlDataReader reader=cmd.ExecuteReader();

            while (reader.Read())
            {
                string sname = reader[0].ToString();
                string splace = reader[1].ToString();
                string sdate = reader[2].ToString();

                string  msg = sname + "-" + splace + "on" + sdate;
                EventGroupBoxlist.Items.Add(msg);

            }

            Conn.Close();

            


        }
    }
}
