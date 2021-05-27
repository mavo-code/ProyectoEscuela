namespace proyecto_escuela.Entidades
{
    /// <summary>
    /// Enumerador del nombre de las propiedades de diccionarios
    /// </summary>
    public enum LlaveDiccionario
    {
        Alumnos,
        Cursos,
        Asignaturas,
        Escuela,
        Evaluaciones
    }

    /// <summary>
    /// Estructura con los nombres de las propiedades de diccionarios
    /// </summary>
    public struct LlavesDiccionario
    {
        public const string ALUMNOS = "Alumnos";
        public const string CURSOS = "Cursos";
        public const string ASIGNATURAS = "Asignaturas";
        public const string ESCUELA = "Escuela";
        public const string EVALUACIONES = "Evaluaciones";
    }
}