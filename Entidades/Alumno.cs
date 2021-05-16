using System;
using System.Collections.Generic;

namespace proyecto_escuela.Entidades
{
    public class Alumno
    {
        public string uniqueId { get; set; }
        
        public string nombre { get; set; }

        public List<Evaluaciones> evaluaciones { get; set; } =  new List<Evaluaciones>();

        public Alumno() => uniqueId = Guid.NewGuid().ToString();
    }
}