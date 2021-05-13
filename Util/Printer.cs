using static System.Console;

namespace proyecto_escuela.Util
{
    /// <summary>
    /// Clase con las utilidades para imprimir
    /// </summary>
    public static class Printer
    {
        public static void dibujarLinea(int tamano = 10)
        {
            WriteLine("".PadLeft(tamano, '='));
        }

        public static void writeTitle(string title)
        {
            var _tamano = title.Length + 4;
            dibujarLinea(_tamano);
            WriteLine($"| {title} |");
            dibujarLinea(_tamano);
        }


        public static void beep(int hz = 2000, int tiempo = 500, int cantidad = 1)
        {
            while(cantidad-- > 0)
            {
                Beep(hz, tiempo);
            }
        }
    }
}