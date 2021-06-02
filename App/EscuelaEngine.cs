using System;
using System.Collections.Generic;
using System.Linq;
using proyecto_escuela.Entidades;
using proyecto_escuela.Util;

namespace proyecto_escuela.App
{
    public sealed class EscuelaEngine
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

        /// <summary>
        /// Imprime los valores del diccionario con los elementos de la escuela
        /// </summary>
        /// <param name="diccionario">Listado con los elementos del diccionario (Obligatorio)</param>
        public void imprimirDiccionario(Dictionary<LlaveDiccionario, IEnumerable<ObjectoEscuelaBase>> diccionario, bool imprimirEvaluaciones = false)
        {
            foreach (var keyDiccionario in diccionario)
            {
                Printer.writeTitle(keyDiccionario.Key.ToString());

                foreach (var itemElementoDiccionario in keyDiccionario.Value)
                {
                    switch (keyDiccionario.Key)
                    {
                        case LlaveDiccionario.Evaluaciones:
                            if (imprimirEvaluaciones)
                                Console.WriteLine(itemElementoDiccionario);
                            break;
                        case LlaveDiccionario.Escuela:
                            Console.WriteLine($"Escuela: {itemElementoDiccionario}");
                            break;
                            case LlaveDiccionario.Alumnos:
                            Console.WriteLine($"Alumno: {itemElementoDiccionario.nombre}");
                            break;
                        case LlaveDiccionario.Cursos:
                            var _cursoTemporal = itemElementoDiccionario as Curso;
                            if (_cursoTemporal != null)
                            {
                                int _cantidadAlumnos = ((Curso)itemElementoDiccionario).alumnos.Count;
                                Console.WriteLine($"Curso: {itemElementoDiccionario.nombre}. Numero de alumnos: {_cantidadAlumnos}");
                            }
                            break;
                        default:
                            Console.WriteLine(itemElementoDiccionario.nombre);
                            break;
                    }
                }
            }
        }



        /// <summary>
        /// Obtiene el diccionario de todos los elementos de las 
        /// </summary>
        /// <returns></returns>
        public Dictionary<LlaveDiccionario, IEnumerable<ObjectoEscuelaBase>> getDiccionarioObjetos()
        {
            Dictionary<LlaveDiccionario, IEnumerable<ObjectoEscuelaBase>> _result = new Dictionary<LlaveDiccionario, IEnumerable<ObjectoEscuelaBase>>();

            _result.Add(LlaveDiccionario.Escuela, new List<ObjectoEscuelaBase>(){_escuela});
            _result.Add(LlaveDiccionario.Cursos, _escuela.cursos.Cast<ObjectoEscuelaBase>());

            var _listaTemporalAsignaturas = new List<Asignatura>();
            var _listaTemporalEvaluaciones = new List<Evaluacion>();
            var _listaTemporalAlumnos = new List<Alumno>();


            foreach (var _cursos in _escuela.cursos)
            {
                _listaTemporalAsignaturas.AddRange(_cursos.asignaturas);
                _listaTemporalAlumnos.AddRange(_cursos.alumnos);

                foreach (var _alumno in _cursos.alumnos)
                {
                    _listaTemporalEvaluaciones.AddRange(_alumno.evaluaciones);
                }
            }
            _result.Add(LlaveDiccionario.Asignaturas, _listaTemporalAsignaturas.Cast<ObjectoEscuelaBase>());
            _result.Add(LlaveDiccionario.Alumnos, _listaTemporalAlumnos.Cast<ObjectoEscuelaBase>());
            _result.Add(LlaveDiccionario.Evaluaciones, _listaTemporalEvaluaciones.Cast<ObjectoEscuelaBase>());
            return _result;
        }

        /// <summary>
        /// Obtiene el listados de los objetos creados de una escuela
        /// </summary>
        /// <param name="traerEvaluaciones">indica si debe traer las evaluaciones (Opcional)</param>
        /// <param name="traerAlumnos">indica si debe de traer los alumnos (Opcional)</param>
        /// <param name="traerAsignaturas">indica si debe traer las asignaturas (Opcional)</param>
        /// <param name="traerCursos">indica si debe traer los cursos (Opcional)</param>
        /// <returns></returns>
        public  IReadOnlyList<ObjectoEscuelaBase>  getObjetosListaBAse(
                out int conteoEvaluaciones,
                out int conteoAlumnos,
                out int conteoAsignaturas,
                out int conteoCursos,
                bool traerEvaluaciones = true,
                bool traerAlumnos = true,
                bool traerAsignaturas = true,
                bool traerCursos = true)
        {
            conteoEvaluaciones = conteoAlumnos = conteoAsignaturas = conteoCursos = 0;

            List<ObjectoEscuelaBase> _resultado = new List<ObjectoEscuelaBase>();
            _resultado.Add(_escuela);

            if (traerAsignaturas)
                _resultado.AddRange(_escuela.cursos);

            conteoCursos += _escuela.cursos.Count();

            foreach (var _curso in _escuela.cursos)
            {
                conteoAsignaturas += _curso.asignaturas.Count();
                conteoAlumnos += _curso.alumnos.Count();

                if (traerAsignaturas)
                    _resultado.AddRange(_curso.asignaturas);
                    
                if (traerAlumnos)
                    _resultado.AddRange(_curso.alumnos);

                if (traerEvaluaciones)
                {
                    foreach (var _alumno in _curso.alumnos)
                    {
                        _resultado.AddRange(_alumno.evaluaciones);
                        conteoEvaluaciones +=  _alumno.evaluaciones.Count;
                    }
                }
            }


            return _resultado;
        }


        #region funciones de carga

        /// <summary>
        /// Carga las evaluaciones de alumnos por curso por asignatura
        /// </summary>
        private void cargarEvaluaciones()
        {
            foreach (var _curso in _escuela.cursos)
            {
                foreach (var _asignatura in _curso.asignaturas)
                {
                    foreach (var _alumno in _curso.alumnos)
                    {
                        var _listaEvaluaciones = generarValoresEvaluaciones();
                        int _parcial = 1;

                        foreach (var _evaluacion in _listaEvaluaciones)
                        {
                            _alumno.evaluaciones.Add(new Evaluacion()
                            {
                                alumno = _alumno,
                                asignatura = _asignatura,
                                nombre = $"Evaluacion de {_asignatura.nombre} correspondiente al parcial {_parcial}",
                                nota = _evaluacion
                            });

                            _parcial ++;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Genera los valores de las evaluaciones de las asignaturas
        /// </summary>
        /// <param name="cantidad">cantidad de calificaciones que se generaran  (Opcional)</param>
        /// <returns></returns>
        private List<float> generarValoresEvaluaciones(int cantidad = 5)
        {
            float _value = 0;
            List<float> _result = new List<float>();

            for (int i = 0; i < cantidad; i++)
            {
                _value = MathF.Round(5 * (float)new Random().NextDouble(), 2);
                _result.Add(_value);
            }
            return _result;
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
                _curso.asignaturas = listaAsignaturas;
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
                                select new Alumno { nombre = $"{n1} {n2} {a1}" };

            return _listaAlumnos.OrderBy((alumno) => alumno.uniqueId).Take(cantidadAlumnos).ToList();
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

        #endregion
    }
}