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
            var _listaPromedioPorAsignatura = _reporteador.getPromedioAlumnoPorAsignatura();
            var _topPromedio = _reporteador.getTopPromedioAlumnos(_asignatura: "Matematicas", _numberTop: 10);

            var _listaPadre = new List<ObjectoEscuelaBase>();
            var _listachild = new List<Alumno>()
            {
                new Alumno
                {
                    nombre = "juanito"
                },
                new Alumno
                {
                    nombre = "juanito"
                },
            };

            _listaPadre.AddRange(_listachild.Cast<ObjectoEscuelaBase>());


            // var _newEval = new Evaluacion();
            // string _nombreAlumnoIngresado, _notaTexto;
            // float _notaAlumno = 0;

            // WriteLine("Ingrese el nombre del alumno");
            // Printer.presioneEnter();

            // _nombreAlumnoIngresado = Console.ReadLine();

            // WriteLine("Ingrese la nota del alumno");
            // Printer.presioneEnter();

            // _notaTexto = Console.ReadLine();

            // if (string.IsNullOrWhiteSpace(_notaTexto))
            // {
            //     Printer.writeTitle("El valor de la nota no puede ser vacio");
            //     WriteLine("Saliendo del programa");
            // }
            // else
            // {
            //     try
            //     {
            //         _newEval.nota = float.Parse(_notaTexto);

            //         if (_newEval.nota < 0 && _newEval.nota > 5)
            //         {
            //             new ArgumentException("El valor de  nota esta fuera de los rangos permitidos");
            //         }
            //     }
            //     catch (ArgumentException _ex)
            //     {
            //         Printer.writeTitle(_ex.Message);
            //         WriteLine("Saliendo del programa");
            //     }
            //     catch (System.Exception _o)
            //     {
            //         Printer.writeTitle("El valor de la nota no puede ser vacio");
            //         WriteLine("Saliendo del programa");
            //     }
            //     finally
            //     {

            //     }

            // }




            
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
