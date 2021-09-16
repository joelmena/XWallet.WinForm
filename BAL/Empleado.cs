using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BAL
{
    public class Empleado : DbConnection
    {
        public int Id { get; set; }
        public string CodigoEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public bool Verificado { get; set; }
        
        
        public bool Saved()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO Empleados (CodigoEmpleado, Nombre, Password, Verificado)");
            sql.AppendLine($"VALUES ('{CodigoEmpleado}', '{Nombre}', PWDENCRYPT('{Password}'), {(Verificado == true ? 1 : 0)})");

            return NonQuery(sql.ToString());
        }
        public bool Updated()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine($"UPDATE Empleados SET CodigoEmpleado = '{CodigoEmpleado}', Nombre = '{Nombre}', Password = PWDENCRYPT('{Password}'), Verificado = {(Verificado == true ? 1 : 0)}");
            sql.AppendLine($" WHERE Id = {Id}");

            return NonQuery(sql.ToString());
        }
        
        public DataTable GetList(string busqueda = null)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT Id, CodigoEmpleado, Nombre, Verificado FROM Empleados");
            if (!string.IsNullOrEmpty(busqueda))
            {
                sql.AppendLine($" WHERE CodigoEmpleado LIKE '%{busqueda}%' OR Nombre LIKE '%{busqueda}%'");
            }
            return QuerySql(sql.ToString());
        }

        public bool Delete()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine($"DELETE FROM Empleados WHERE Id = {Id}");

            return NonQuery(sql.ToString());
        }
    }

}
