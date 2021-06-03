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

        public IEnumerable<string> getListaAsignaturas()
        {
            var _listaEvaluaciones = getListaEvaluaciones();

            return (from Evaluacion _evaluaciones in _listaEvaluaciones
                    select _evaluaciones.asignatura.nombre).Distinct();
        }

    }
}