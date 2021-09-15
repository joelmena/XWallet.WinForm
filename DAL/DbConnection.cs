using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class DbConnection
    {
        private SqlConnection connect;

        public DbConnection(IConfiguration configuration = null)
        {
            //connect = new SqlConnection(configuration.GetConnectionString("SqlConnectionStr"));
            connect = new SqlConnection("Server=172.20.1.2; Database=ConsultaBalance; User Id=xmedical; Password=mdav4000");

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

        public void Saved() { }
        public void Updated() { }

        public DataTable QuerySql(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand cmd = connect.CreateCommand())
                {
                    connect.Open();
                    cmd.Connection = connect;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connect.Close();
            }
            return dt;
        }

        public void GetDetail(string codigo) { }
        public void Delete(string codigo) { }
    }
}
