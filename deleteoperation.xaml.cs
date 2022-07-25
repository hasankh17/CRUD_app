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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }
        
        SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-EKH75FM;Initial Catalog=DCS;Integrated Security=True");

        Shareable_methods obj_class = new Shareable_methods();
        obj_class.LoadData();
     
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-EKH75FM;Initial Catalog=DCS;Integrated Security=True");

            sqlcon.Open();

            SqlCommand sqlcom = new SqlCommand("DELETE FROM DemoDatabase.dbo.UserData where ID = "+search_txt.Text+" ", sqlcon);

            try
            {
                sqlcom.ExecuteNonQuery();
                MessageBox.Show("Record Deleted Successfully","Deleted", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                sqlcon.Close();
                LoadData(GetDatagrid());
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
