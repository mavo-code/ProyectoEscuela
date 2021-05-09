using System;
using System.Collections.Generic;
using proyecto_escuela.Entidades;
using static System.Console;

namespace proyecto_escuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Platzi Academy", 2011, TiposEscuela.Primaria, pais: "Mexico", ciudad: "Cuernavaca");
            Console.WriteLine(escuela.ToString());

            escuela.cursos = new List<Curso>(){
                new Curso(){nombre = "101", jornada = TiposJornada.Mañana},
                new Curso(){nombre = "201", jornada = TiposJornada.Mañana},
                new Curso(){nombre = "301", jornada = TiposJornada.Mañana}
            };

            escuela.cursos.Add(new Curso() {nombre= "102", jornada = TiposJornada.Tarde});
            escuela.cursos.Add(new Curso() {nombre= "202", jornada = TiposJornada.Tarde});

            var otraColeccion = new List<Curso>(){
                new Curso(){nombre = "401", jornada = TiposJornada.Mañana},
                new Curso(){nombre = "501", jornada = TiposJornada.Mañana},
                new Curso(){nombre = "501", jornada = TiposJornada.Tarde}
            };

            escuela.cursos.AddRange(otraColeccion);

            // escuela.cursos.RemoveAll(delegate (Curso _curso) {
            //                             return _curso.nombre == "301";
            //                         });

            // escuela.cursos.RemoveAll((_curso) => _curso.nombre == "501" && _curso.jornada == TiposJornada.Tarde);   

            imprimirCursosEscuela(escuela);
        }

        /// <summary>
        /// Funcion para imprimir la lista de cursos
        /// </summary>
        /// <param name="escuela">objeto de tipo escuela con la informacion de los cursos</param>
        private static void imprimirCursosEscuela(Escuela escuela)
        {
            WriteLine("=============================");
            WriteLine("Cursos de la escuela");
            WriteLine("=============================");

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
