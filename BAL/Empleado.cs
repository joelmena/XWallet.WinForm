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
        public byte[] Password { get; set; }
        public bool Verificado { get; set; }
        
        
        public void Saved() { }
        public void Updated() { }
        
        public DataTable GetList(string busqueda = null)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT Id, CodigoEmpleado, Nombre, Verificado FROM Empleados");
            if (!string.IsNullOrEmpty(busqueda))
            {
                sql.AppendLine($"WHERE CodigoEmpleado LIKE '%{busqueda}%' OR Nombre LIKE '%{busqueda}%'");
            }
            return QuerySql(sql.ToString());
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
