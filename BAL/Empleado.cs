using System;

namespace BAL
{
    public class Empleado
    {
        public int Id { get; set; }
        public string CodigoEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public bool Verificado { get; set; }
        
        
        public void Saved() { }
        public void Updated() { }
        public void GetList(string busqueda) { }
        public void GetDetail(string codigo) { }
        public void Delete(string codigo) { }
    }

}
