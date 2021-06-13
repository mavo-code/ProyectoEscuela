using System;
using System.Collections.Generic;
using System.Linq;
using proyecto_escuela.Entidades;

namespace proyecto_escuela.App
{
    public class Reporteador
    {
        Dictionary<LlaveDiccionario, IEnumerable<ObjectoEscuelaBase>> _diccionarioEscuela;
        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjectoEscuelaBase>> diccionarioEscuela)
        {
            if (diccionarioEscuela == null)
                throw new ArgumentException(nameof(diccionarioEscuela));


            _diccionarioEscuela = diccionarioEscuela;
        }

        /// <summary>
        /// Obtiene la lista de evaluaciones 
        /// </summary>
        /// <returns>IENUMERABLE<Evaluaciones></returns>
        public IEnumerable<Evaluacion> getListaEvaluaciones()
        {
            if (_diccionarioEscuela.TryGetValue(LlaveDiccionario.Evaluaciones, out IEnumerable<ObjectoEscuelaBase> _listaEscuela))
            {
                return _listaEscuela.Cast<Evaluacion>();
            }
            else
            {
                return new List<Evaluacion>();
            }
        }

        /// <summary>
        /// Obtiene el listado de nombres de asignaturas
        /// </summary>
        /// <returns>IENUMERABLE<string></returns>
        public IEnumerable<string> getListaAsignaturas()
        {
            return getListaAsignaturas(out var dummy);
        }

        /// <summary>
        /// Obtiene el listado de nombres de asignaturas y ademas el listado de evaluaciones
        /// </summary>
        /// <param name="listaEvaluaciones">lista de evaluaciones (OUT) (Obligatorio)</param>
        /// <returns>IENUMERABLE<string></returns>
        public IEnumerable<string> getListaAsignaturas(out IEnumerable<Evaluacion> listaEvaluaciones)
        {
            listaEvaluaciones = getListaEvaluaciones();

            return (from Evaluacion _evaluaciones in listaEvaluaciones
                    select _evaluaciones.asignatura.nombre).Distinct();
        }

        /// <summary>
        /// Obtiene el diccionario de  asignatura por evaluacion
        /// </summary>
        /// <returns>Dictionary<string, IEnumerable<Evaluacion>></returns>
        public Dictionary<string, IEnumerable<Evaluacion>> getDicccionarioAsignaturaPorEvaluaciones()
        {
            var _diccionarioAsignaturaPorEvaluaciones = new Dictionary<string, IEnumerable<Evaluacion>>();

            var _listaAsignatura = getListaAsignaturas(out var _listaEvaluaciones);

            foreach (var _asignatura in _listaAsignatura)
            {
                var _evaluacionesAsignatura = from _evaluacion in _listaEvaluaciones
                                              where _evaluacion.asignatura.nombre == _asignatura
                                              select _evaluacion;

                _diccionarioAsignaturaPorEvaluaciones.Add(_asignatura, _evaluacionesAsignatura);
            }

            return _diccionarioAsignaturaPorEvaluaciones;
        }

        /// <summary>
        /// Obtiene el reporte del promedio de alumnos por asignatura
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, IEnumerable<object>> getPromedioAlumnoPorAsignatura()
        {
            var _response = new Dictionary<string, IEnumerable<object>>();
            var _asignaturaPorEvaluaciones = getDicccionarioAsignaturaPorEvaluaciones();

            foreach (var _asignaturaEvaluacion in _asignaturaPorEvaluaciones)
            {
                var _alumnosPromedios = from _evaluacion in _asignaturaEvaluacion.Value
                                        group _evaluacion by new {
                                            _evaluacion.alumno.uniqueId,
                                            _evaluacion.nombre
                                            }
                                        into grupoEvaluacionesAlumnos
                                        select new AlumnoPromedio{
                                            alumnoId = grupoEvaluacionesAlumnos.Key.uniqueId,
                                            nombre = grupoEvaluacionesAlumnos.Key.nombre,
                                            promedio = grupoEvaluacionesAlumnos.Average(x => x.nota)
                                        };
                _response.Add(_asignaturaEvaluacion.Key, _alumnosPromedios);
            }

            return _response;
        }

        /// <summary>
        /// Obtiene el listado de top promedio solicitados
        /// </summary>
        /// <param name="_asignatura">nombre de la asignatura/param>
        /// <param name="_numberTop">numero de registros que se desean devolver</param>
        /// <returns></returns>
        public Dictionary<string, IEnumerable<AlumnoPromedio>> getTopPromedioAlumnos(string _asignatura, int _numberTop)
        {
            var _response = new Dictionary<string, IEnumerable<AlumnoPromedio>>();
            var _asignaturaPorEvaluaciones = getDicccionarioAsignaturaPorEvaluaciones();

            var _topAlumnosPromedios = (from _topEvaluaciones in _asignaturaPorEvaluaciones.Where(x => x.Key == _asignatura).Select(y => y.Value).FirstOrDefault()
                                        orderby _topEvaluaciones.nota descending
                                        group _topEvaluaciones by new {
                                                _topEvaluaciones.alumno.uniqueId,
                                                _topEvaluaciones.nombre
                                        }
                                        into grupoTop
                                        select new AlumnoPromedio{
                                            alumnoId = grupoTop.Key.uniqueId,
                                            nombre = grupoTop.Key.nombre,
                                            promedio = grupoTop.Select(x => x.nota).FirstOrDefault()
                                        }).Take(_numberTop);

            _response.Add(_asignatura, _topAlumnosPromedios);


            return _response;
        }

        

    }
}