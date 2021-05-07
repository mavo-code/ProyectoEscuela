using System;
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

            escuela.cursos = new Curso[]{
                new Curso(){nombre = "101"},
                new Curso(){nombre = "202"},
                new Curso(){nombre = "303"}
            };

            escuela = null;
            imprimirCursosEscuela(escuela);
        }

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
