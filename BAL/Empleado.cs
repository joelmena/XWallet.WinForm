﻿using DAL;
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
        
        
        public bool Saved(Empleado empleado)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO Empleados (CodigoEmpleado, Nombre, Password, Verificado)");
            sql.AppendLine($"VALUES ('{CodigoEmpleado}', '{Nombre}', PWDENCRYPT('{Password}'), {(Verificado == true ? 1 : 0)})");

            return NonQuery(sql.ToString());
        }
        public void Updated() { }
        
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

        public void Delete(string codigo)
        {

        }
    }

}
