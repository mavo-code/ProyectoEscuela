using System;

namespace proyecto_escuela.Entidades
{
    public class Alumno
    {
        public string uniqueId { get; set; }
        
        public string nombre { get; set; }

        public Alumno() => uniqueId = Guid.NewGuid().ToString();
    }
}