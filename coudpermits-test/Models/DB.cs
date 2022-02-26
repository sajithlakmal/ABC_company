using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using coudpermits_test.ViewModel;

namespace coudpermits_test.Models
{
  

	}
    public class DB
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-6K34ULM;Initial Catalog=ABC;Integrated Security=True");
        public int LoginCheck(LoginViewModel ad)
        {
            SqlCommand com = new SqlCommand("login", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@email", ad.Email);
            com.Parameters.AddWithValue("@password", ad.Password);
            SqlParameter oblogin = new SqlParameter();
            oblogin.ParameterName = "@Isvalid";
            oblogin.SqlDbType = SqlDbType.Bit;
            oblogin.Direction = ParameterDirection.Output;
            com.Parameters.Add(oblogin);
            con.Open();
            com.ExecuteNonQuery();
            int res = Convert.ToInt32(oblogin.Value);
            con.Close();
            return res;
        }
}
