using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
            if (args.Length == 0)
            {
                Console.WriteLine("Uso: ngi18nhelper <fichero sin traducir> <diccionario ResX or XLIFF> <fichero resultado XLIFF>");
                return;
            }


            var plantillaFichero = args[0];
            var traduccionFichero = args[1];
            var resultadoFichero = args[2];

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
