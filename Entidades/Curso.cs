using System;
using System.Collections.Generic;
using proyecto_escuela.Util;

namespace proyecto_escuela.Entidades
{
    ///Clase con las propiedades de curso
    public class Curso : ObjectoEscuelaBase, ILugar
    {
        public TiposJornada jornada { get; set; }

        public List<Asignatura> asignaturas { get; set; }

        public List<Alumno> alumnos { get; set; }

        /// <summary>
        /// Propiedada implemetada de forma explicita
        /// </summary>
        /// <value></value>
        string ILugar.direccion { get; set; }

        public void limpiarLuagr()
        {
            Printer.drawLine();
            Printer.writeTitle("Limpiando el estableceimiento...");
            Printer.writeTitle($"Curso {nombre} limpio");
        }
    }
}