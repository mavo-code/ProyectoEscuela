using System;

namespace proyecto_escuela.Entidades
{
    public class Evaluacion : ObjectoEscuelaBase
    {
        public Alumno alumno { get; set; }
        
        public Asignatura asignatura { get; set; }

        public float nota { get; set; }

        public override string ToString()
        {
            return $"{nota}, {alumno.nombre} {asignatura.nombre}";
        }
    }
}