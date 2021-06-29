using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ng_i18n_helper.Lectores
{
    class LectorXLIFF : ILector
    {
        public Dictionary<string, string> Leer(string fichero)
        {
            var res = new Dictionary<string, string>();

            var xelement = XElement.Load(fichero);
            var ns = xelement.Name.Namespace;

            var elements = xelement.Descendants().Elements(ns + "trans-unit");
            foreach (var element in elements)
            {
                var key = element.Attribute("id").Value;
                var source = element.Element(ns + "source").Value;
                res.Add(key, source);
            }

            return res;
        }

        public List<string> Validar(string fichero)
        {
            var xelement = XElement.Load(fichero);
            var ns = xelement.Name.Namespace;
            var res = new List<string>();

            var elements = xelement.Descendants().Elements(ns + "trans-unit");
            foreach (var element in elements)
            {
                var key = element.Attribute("id").Value;
                var target = element.Element(ns + "target")?.Value;
                if (string.IsNullOrEmpty(target))
                    res.Add(key);
            }

            return res;
        }
    }
}
