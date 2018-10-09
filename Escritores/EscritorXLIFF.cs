using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ng_i18n_helper.Escritores
{
    class EscritorXLIFF : IEscritor
    {
        public void Escribir(string fichero, Dictionary<string, string> terminos, string destino)
        {
            var xelement = XElement.Load(fichero);
            var ns = xelement.Name.Namespace;

            var elements = xelement.Descendants().Elements(ns + "trans-unit");
            foreach (var element in elements)
            {
                var key = element.Attribute("id").Value;
                if (terminos.ContainsKey(key))
                {
                    var elemento = new XElement(ns + "target");
                    elemento.Value = terminos[key];
                    element.Add(elemento);
                }
            }

            File.WriteAllText(destino, xelement.ToString());
        }
    }
}
