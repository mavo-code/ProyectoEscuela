using System;
using System.Collections.Generic;
using System.Linq;
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

            cargarCursos();
            cargarAsignaturas();
            cargarEvaluaciones();

        }

        private void cargarEvaluaciones()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Carga la lista de asignaturas
        /// </summary>
        private void cargarAsignaturas()
        {
            foreach (var _curso in _escuela.cursos)
            {
                List<Asignatura> listaAsignaturas = new List<Asignatura>()
                {
                    new Asignatura(){nombre = "Matematicas"},
                    new Asignatura(){nombre = "Educacion Fisica"},
                    new Asignatura(){nombre = "Castellano"},
                    new Asignatura(){nombre = "Ciencias Naturales"},
                    new Asignatura(){nombre = "Historia"}
                };
                _curso.asignaturtas = listaAsignaturas;
            }
        }

        /// <summary>
        /// Carga la lista de los ALumnos de forma aleatoria
        /// </summary>
        /// <returns></returns>
        private List<Alumno> generarAlumnosAleatorios(int cantidadAlumnos)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };

            var _listaAlumnos = from n1 in nombre1
                                from n2 in nombre2
                                from a1 in apellido1
                                select new Alumno{nombre=$"{n1} {n2} {a1}"};

            return _listaAlumnos.OrderBy((alumno)=>alumno.uniqueId).Take(cantidadAlumnos).ToList();
        }

        /// <summary>
        /// Carga la lista de cursos
        /// </summary>
        private void cargarCursos()
        {
            _escuela.cursos = new List<Curso>(){
                new Curso(){nombre = "101", jornada = TiposJornada.Mañana},
                new Curso(){nombre = "201", jornada = TiposJornada.Mañana},
                new Curso(){nombre = "301", jornada = TiposJornada.Mañana},
                new Curso(){nombre = "401", jornada = TiposJornada.Tarde},
                new Curso(){nombre = "501", jornada = TiposJornada.Tarde}
            };

            Random _random = new Random();

            foreach (var _curso in _escuela.cursos)
            {
                int cantidadRandom = _random.Next(5, 20);
                _curso.alumnos = generarAlumnosAleatorios(cantidadRandom);
            }
        }
    }
}