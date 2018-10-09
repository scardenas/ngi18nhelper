using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ng_i18n_helper.Escritores;

namespace ng_i18n_helper.Lectores
{
    public interface ILector
    {
        Dictionary<string, string> Leer(string fichero);
        List<string> Validar(string fichero);
    }

    public static class LectorFactory
    {
        public static ILector Get(string fichero)
        {
            switch (Path.GetExtension(fichero))
            {
                case ".resx":
                    return new LectorResX();

                case ".xlf":
                case ".xliff":
                case ".xlif":
                    return new LectorXLIFF();

                default:
                    Console.WriteLine("El fichero con términos traducidor tiene una extensión no compatible");
                    return null;
            }
        }
    }
}
