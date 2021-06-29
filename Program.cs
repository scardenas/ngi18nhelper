using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ng_i18n_helper.Escritores;
using ng_i18n_helper.Lectores;

namespace ng_i18n_helper
{
    class Program
    {
        static void Main(string[] args)
        {
            var plantillaFichero = Environment.GetEnvironmentVariable("ORIGIN");
            var traduccionFichero = Environment.GetEnvironmentVariable("RESX");
            var resultadoFichero = Environment.GetEnvironmentVariable("TARGET");

            if (!File.Exists(plantillaFichero))
            {
                Console.WriteLine("No se puede encontrar el fichero plantilla");
                return;
            }

            if (!File.Exists(traduccionFichero))
            {
                Console.WriteLine("No se puede encontrar el fichero de diccionario");
                return;
            }

            if (Path.GetExtension(plantillaFichero) != Path.GetExtension(resultadoFichero)) 
            {
                Console.WriteLine("La extensión del fichero resultado debe ser la misma que la del fichero plantilla");
                return;
            }

            Console.WriteLine("Iniciando proceso");


            // Lectura del diccionario
            var lector = LectorFactory.Get(traduccionFichero);
            if (lector == null)
                return;

            var diccionario = lector.Leer(traduccionFichero);


            // Escritura
            var escritor = EscritorFactory.Get(plantillaFichero);
            if (escritor == null)
                return;

            escritor.Escribir(plantillaFichero, diccionario, resultadoFichero);

            // Validación
            var validador = LectorFactory.Get(resultadoFichero);
            var validacion = validador.Validar(resultadoFichero);
            if (validacion.Any())
            {
                Console.WriteLine("Falta por traducir: ");
                validacion.ForEach(Console.WriteLine);
            }
            else
                Console.WriteLine("El fichero resultante está completo");
        }
    }
}
