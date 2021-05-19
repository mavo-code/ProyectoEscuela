using System;
using System.Collections.Generic;

namespace proyecto_escuela.Entidades
{
    public class Escuela : ObjectoEscuelaBase
    {
        public int anioDeCreacion { get; set; }
        
        public string pais { get; set; }

        public string ciudad { get; set; }
        
        public TiposEscuela tipoEscuela { get; set; }

        public List<Curso> cursos { get; set; }

        public Escuela (string nombreEscuela, int anioDeCreacion) => (nombre, this.anioDeCreacion) = (nombreEscuela, anioDeCreacion);

        public Escuela(string nombreEscuela, int anioDeCreacion, TiposEscuela tipoEscuela, string pais = "", string ciudad = "")
        {
            (nombre, this.anioDeCreacion) = (nombreEscuela, anioDeCreacion);
            this.tipoEscuela = tipoEscuela;
            this.pais = pais;
            this.ciudad = ciudad;
        }

        public override string ToString()
        {
            return $"Nombre: \"{nombre}\", Año: {anioDeCreacion}, Pais: {pais}, {System.Environment.NewLine} Ciudad: {ciudad}, Tipo de escuela: {tipoEscuela}";
        }

    }
}