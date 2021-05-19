using System;
using System.Collections.Generic;

namespace proyecto_escuela.Entidades
{
    ///Clase con las propiedades de curso
    public class Curso : ObjectoEscuelaBase
    {
        public TiposJornada jornada { get; set; }

        public List<Asignatura> asignaturas { get; set; }

        public List<Alumno> alumnos { get; set; }
    }
}