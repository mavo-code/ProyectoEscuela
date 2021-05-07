using System;
namespace proyecto_escuela.Entidades
{
    ///Clase con las propiedades de curso
    public class Curso
    {
        public string uniqueId { get; private set; }
        
        public string nombre { get; set; }

        public TiposJornada jornada { get; set; }

        public Curso() => (uniqueId) = (Guid.NewGuid().ToString());
    }
}