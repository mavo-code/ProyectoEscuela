using System;
using System.Collections.Generic;

namespace proyecto_escuela.Entidades
{
    public class Escuela
    {

        public string uniqueId { get; private set; } = Guid.NewGuid().ToString();

        private string _nombre;
        public string nombre
        {
            get { return $"Copia: {_nombre}"; }
            set { _nombre = value.ToUpper(); }
        }

        public int anioDeCreacion { get; set; }
        
        public string pais { get; set; }

        public string ciudad { get; set; }
        
        public TiposEscuela tipoEscuela { get; set; }

        public List<Curso> cursos { get; set; }

        public Escuela (string nombreEscuela, int anioDeCreacion) => (_nombre, this.anioDeCreacion) = (nombreEscuela, anioDeCreacion);

        public Escuela(string nombreEscuela, int anioDeCreacion, TiposEscuela tipoEscuela, string pais = "", string ciudad = "")
        {
            (_nombre, this.anioDeCreacion) = (nombreEscuela, anioDeCreacion);
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