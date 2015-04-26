using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace BloodBankManagementSystem
{
    /// <summary>
    ///     Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow
    {
        public static SqlConnection Conn;

        public UserWindow()
        {
            InitializeComponent();
        }


        private void TC_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var ti = TC.SelectedItem as TabItem;
            if (ti != null) Title = ti.Header.ToString();
        }

        private void SearchbyMobilenoButton_Click(object sender, RoutedEventArgs e)
        {
            Conn = DatabaseConnection.GetConnection();

            if (Conn.State.ToString() == "closed")
            {
                Conn.Open();
            }


            String query =
                string.Format("select Id,Name,Bloodgroup,Address,Currentcity from information where Phonenumber='" +
                              MobilenoTextBox.Text + "'");


            var ds = new DataSet();
            var adapter = new SqlDataAdapter();
            try
            {
                var cmd = new SqlCommand(query, Conn);
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);

                MobilenoListView.DataContext = ds.Tables[0].DefaultView; //DataGrid
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Conn.Close();
        }

        private void OkayButton2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OkayButton1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OkayButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    

        private void SearchbybloodgroupButton_OnClick(object sender, RoutedEventArgs e)
        {
            Conn = DatabaseConnection.GetConnection();

            if (Conn.State.ToString() == "closed")
            {
                Conn.Open();
            }


            String query =
                string.Format("select Id,Name,Phonenumber,Address,Currentcity from information where Bloodgroup='" +
                              BloodgroupComboBox.SelectionBoxItem + "'");


            var ds = new DataSet();
            var adapter = new SqlDataAdapter();
            try
            {
                var cmd = new SqlCommand(query, Conn);
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);

                BloodgroupListView.DataContext = ds.Tables[0].DefaultView; //DataGrid
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Conn.Close();
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SearchbyCurrentcityButton_OnClick(object sender, RoutedEventArgs e)
        {
            Conn = DatabaseConnection.GetConnection();

            if (Conn.State.ToString() == "closed")
            {
                Conn.Open();
            }


            String query =
                string.Format("select Id,Name,Bloodgroup,Phonenumber,Address from information where Currentcity='" +
                              CurrentcityTextBox.Text + "'");


            var ds = new DataSet();
            var adapter = new SqlDataAdapter();
            try
            {
                var cmd = new SqlCommand(query, Conn);
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);

                CurrentcityListView.DataContext = ds.Tables[0].DefaultView; //DataGrid
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Conn.Close();
        }

        private void SearchbyNameButton_OnClick(object sender, RoutedEventArgs e)
        {
            Conn = DatabaseConnection.GetConnection();

            if (Conn.State.ToString() == "closed")
            {
                Conn.Open();
            }


            String query =
                string.Format("select Id,Bloodgroup,Phonenumber,Address,Currentcity from information where Name='" +
                              NameBox.Text + "'");


            var ds = new DataSet();
            var adapter = new SqlDataAdapter();
            try
            {
                SqlCommand cmd = new SqlCommand(query, Conn);
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);

                NameListView.DataContext = ds.Tables[0].DefaultView; //DataGrid
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Conn.Close();
        }
    }
}