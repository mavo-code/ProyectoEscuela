using System;
using System.Collections.Generic;

namespace proyecto_escuela.Entidades
{
    ///Clase con las propiedades de curso
    public class Curso
    {
        public string uniqueId { get; private set; }
        
        public string nombre { get; set; }

        public TiposJornada jornada { get; set; }

        public List<Asignatura> asignaturas { get; set; }

        public List<Alumno> alumnos { get; set; }

        public Curso() => (uniqueId) = (Guid.NewGuid().ToString());
    }
}