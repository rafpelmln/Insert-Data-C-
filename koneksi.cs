using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 1. 
using System.Data.SqlClient;


namespace insertfarrel
{
     class koneksi
    {
        // 2.
        public SqlConnection GetConn()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = "Data source = DESKTOP-96M8SDH\\SQLEXPRESS; initial catalog=masukin; integrated security=true";
            return Conn;    
        }
    }
}
