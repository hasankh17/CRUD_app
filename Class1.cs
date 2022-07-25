using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo__Project
{
    internal class Shareable_methods
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-EKH75FM;Initial Catalog=DCS;Integrated Security=True");

        private void LoadData(object datagrid)
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



    }
}
