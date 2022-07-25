using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Demo__Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            
        }
        Shareable_methods obj_class = new Shareable_methods();
        SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-EKH75FM;Initial Catalog=DCS;Integrated Security=True");
        
        public void LoadData()
        {
            String query = "SELECT * FROM DemoDatabase.dbo.UserData";
            SqlCommand sqlcom = new SqlCommand(query, sqlcon);
            DataTable dt = new DataTable();
            sqlcon.Open();

            SqlDataReader sdr = sqlcom.ExecuteReader();
            dt.Load(sdr);
            sqlcon.Close();

            Datagrid.ItemsSource = dt.DefaultView;

        }

        public void ClearData()
        {
            txtname.Clear();
            txtage.Clear();
            txtgender.Clear();
            txtcity.Clear();
            search_txt.Clear();
        }

        

     

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            //sqlcon.Open();
            //SqlCommand sqlcom = new SqlCommand("DELETE FROM DemoDatabse.dbo.UserData where ID" , sqlcon);
            Window2 deletewindow = new Window2();
            deletewindow.Show();
            

        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {

        }


        public bool isValid()
        {
            if (txtname.Text == string.Empty)
            {
                MessageBox.Show("Name is required" ,"Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (txtage.Text == string.Empty)
            {
                MessageBox.Show("Age is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (txtgender.Text == string.Empty)
            {
                MessageBox.Show("Gender is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (txtcity.Text == string.Empty)
            {
                MessageBox.Show("City is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isValid())
                {
                    SqlCommand sqlcom = new SqlCommand("INSERT INTO DemoDatabase.dbo.UserData VALUES (@Name, @Age, @Gender, @City)", sqlcon);
                    sqlcom.CommandType = CommandType.Text;
                    sqlcom.Parameters.AddWithValue("@Name", txtname.Text);
                    sqlcom.Parameters.AddWithValue("@Age", txtage.Text);
                    sqlcom.Parameters.AddWithValue("@Gender", txtgender.Text);
                    sqlcom.Parameters.AddWithValue("@City", txtcity.Text);
                    sqlcon.Open();
                    sqlcom.ExecuteNonQuery();
                    sqlcon.Close();
                    LoadData();
                    MessageBox.Show("Registered Succesfully", "Info Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            

        }
    }
}
