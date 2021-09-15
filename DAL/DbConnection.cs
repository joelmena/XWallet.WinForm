using System;
using System.Data.SqlClient;

namespace DAL
{
    public class DbConnection
    {
        private SqlCommand command;
        private SqlDataAdapter adapter;
        private SqlConnection connect;
        SqlConnectionStringBuilder cnn;

        public DbConnection()
        {
            connect = new SqlConnection("server=172.20.1.2;Database=consultaBalance;User Id=xmedical;Password=mdav4000");
        }

        public bool Open()
        {
            try
            {
                connect.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
