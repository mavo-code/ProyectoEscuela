﻿using proyecto_escuela.Entidades;
using proyecto_escuela.App;
using static System.Console;
using proyecto_escuela.Util;
using System.Linq;

namespace proyecto_escuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var _engine = new EscuelaEngine();
            _engine.Inicializar();
            Printer.writeTitle("BIENVENIDOS A LA ESCUELA");
            // Printer.beep(10000, 500, 10);
            imprimirCursosEscuela(_engine._escuela);

            var _listaObjetosEscuela = _engine.getObjetosListaBAse();

            var _listILugar = from obj in _listaObjetosEscuela
                              where obj is ILugar
                              select (ILugar) obj;

            // _engine._escuela.limpiarLuagr();
        }

        /// <summary>
        /// Funcion para imprimir la lista de cursos
        /// </summary>
        /// <param name="escuela">objeto de tipo escuela con la informacion de los cursos</param>
        private static void imprimirCursosEscuela(Escuela escuela)
        {
            Printer.writeTitle("Cursos de la escuela");

            if (escuela?.cursos != null)
            {
                foreach (var _curso in escuela.cursos)
                {
                    WriteLine($"{_curso.uniqueId}, {_curso.nombre}");
                }
            }
        }
    }
}
