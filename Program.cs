using proyecto_escuela.Entidades;
using proyecto_escuela.App;
using static System.Console;
using proyecto_escuela.Util;
using System.Linq;
using System.Collections.Generic;
using System;

namespace proyecto_escuela
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;
            AppDomain.CurrentDomain.ProcessExit += (Object, S) => Printer.beep(2000, 1000, 1);

            var _engine = new EscuelaEngine();
            _engine.Inicializar();
            Printer.writeTitle("BIENVENIDOS A LA ESCUELA");
            // Printer.beep(10000, 500, 10);
            imprimirCursosEscuela(_engine._escuela);

            var _diccionarioTemporal = _engine.getDiccionarioObjetos();

            // _engine.imprimirDiccionario(_diccionarioTemporal, true);

            var _reporteador = new Reporteador(_diccionarioTemporal);
            _reporteador.getListaEvaluaciones();
            _reporteador.getListaAsignaturas();
            _reporteador.getDicccionarioAsignaturaPorEvaluaciones();
        }

        private static void AccionDelEvento(object sender, EventArgs e)
        {
            Printer.writeTitle("SALIENDO DEL SISTEMA");
            Printer.beep(3000, 1000, 3);
            Printer.writeTitle("SALIO");
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
