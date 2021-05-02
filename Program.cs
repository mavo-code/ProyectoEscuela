using System;

namespace proyecto_escuela
{
    
    class clsEscuela
    {
        public string nombreEscuela { get; set; }

        public string direccion { get; set; }

        public int añoFundacion { get; set; }

        public void timbrar()
        {
            Console.Beep(1000, 3000);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            clsEscuela _escuela = new clsEscuela();

            _escuela.timbrar();
            // Console.WriteLine("Hello World!");
        }
    }
}
