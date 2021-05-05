using System;
using proyecto_escuela.Entidades;

namespace proyecto_escuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Platzi Academy", 2011, TiposEscuela.Primaria, pais: "Mexico", ciudad: "Cuernavaca");
            Console.WriteLine(escuela.ToString());
        }
    }
}
