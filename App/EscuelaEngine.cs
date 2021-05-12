using System;
using System.Collections.Generic;
using proyecto_escuela.Entidades;

namespace proyecto_escuela.App
{
    public class EscuelaEngine
    {
        public Escuela _escuela { get; set; }

        public EscuelaEngine()
        {
        }

        public void Inicializar()
        {
            _escuela = new Escuela("Platzi Academy", 2011, TiposEscuela.Primaria, pais: "Mexico", ciudad: "Cuernavaca");

            _escuela.cursos = new List<Curso>(){
                new Curso(){nombre = "101", jornada = TiposJornada.Mañana},
                new Curso(){nombre = "201", jornada = TiposJornada.Mañana},
                new Curso(){nombre = "301", jornada = TiposJornada.Mañana},
                new Curso(){nombre = "401", jornada = TiposJornada.Tarde},
                new Curso(){nombre = "501", jornada = TiposJornada.Tarde},
            };

        }
    }
}