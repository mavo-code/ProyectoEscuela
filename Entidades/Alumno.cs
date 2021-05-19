using System;
using System.Collections.Generic;

namespace proyecto_escuela.Entidades
{
    public class Alumno : ObjectoEscuelaBase
    {
        public List<Evaluacion> evaluaciones { get; set; } =  new List<Evaluacion>();

    }
}