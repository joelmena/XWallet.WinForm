using DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace BAL
{
    public class Empleado : DbConnection
    {
        public int Id { get; set; }
        public string CodigoEmpleado { get; set; }
        public string Nombre { get; set; }
        public byte[] Password { get; set; }
        public bool Verificado { get; set; }
        
        
        public void Saved() { }
        public void Updated() { }
        
        public DataTable GetList(string busqueda = null)
        {
            string sql = @"SELECT 
                            Id, 
                            CodigoEmpleado, 
                            Nombre, 
                            Verificado 
                        FROM Empleados";

            return QuerySql(sql);
        }

        public void GetDetail(string codigo) { }
        public void Delete(string codigo) { }


        public bool Open()
        {
            var cnn = new DbConnection();
            return cnn.Open();
        }
    }

}
