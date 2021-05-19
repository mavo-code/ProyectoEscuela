using System;

namespace proyecto_escuela.Entidades
{
    public class ObjectoEscuelaBase
    {
        public string uniqueId { get; private set; }

        public string nombre { get; set; }

        public ObjectoEscuelaBase() => (uniqueId) = (Guid.NewGuid().ToString());
    }
}