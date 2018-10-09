using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ng_i18n_helper.Escritores
{
    public interface IEscritor
    {
        void Escribir(string fichero, Dictionary<string, string> terminos, string destino);
    }

    public static class EscritorFactory
    {
        public static IEscritor Get(string fichero)
        {
            switch (Path.GetExtension(fichero))
            {
                case ".xlf":
                case ".xliff":
                case ".xlif":
                    return new EscritorXLIFF();

                default:
                    Console.WriteLine("El fichero con términos traducidor tiene una extensión no compatible");
                    return null;
            }
        }
    }
}
