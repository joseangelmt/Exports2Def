using System;
using System.IO;
using System.Linq;

namespace Exports2Def
{
    class Program
    {
        static void Main(string[] args)
        {
            if( args.Length < 2 )
            {
                Console.Error.WriteLine("Error, no se han especificado suficientes parámetros.");
                return;
            }

            var i = 0;
            var líneas = File.ReadAllLines(args[0]);
            using(var archivo = new StreamWriter(args[1]))
            {
                archivo.WriteLine($";{args[1]}: Creado automáticamente por Exports2Def");
                archivo.WriteLine();
                archivo.WriteLine("EXPORTS");

                foreach(var línea in líneas.Skip(16))
                {
                    var palabras = línea.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (palabras.Length < 4)
                        continue;
                    archivo.WriteLine($"{palabras[3]}\t@{++i}\tNONAME");
                }
            }
        }
    }
}
