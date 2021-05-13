using System;

namespace proyecto_escuela.Entidades
{
    public class Evaluaciones
    {
        public string uniqueId { get; private set; }

        public string nombre { get; set; }

        public Alumno alumno { get; set; }
        
        public Asignatura asignatura { get; set; }

        public float nota { get; set; }

        public Evaluaciones() => uniqueId = Guid.NewGuid().ToString();
    }
}