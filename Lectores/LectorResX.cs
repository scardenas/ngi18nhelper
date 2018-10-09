using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ng_i18n_helper.Lectores
{
    class LectorResX  : ILector
    {
        public Dictionary<string, string> Leer(string fichero)
        {
            var xelement = XElement.Load(fichero);
            var res = new Dictionary<string, string>();

            var elements = xelement.Elements("data");
            foreach (var element in elements)
            {
                var key = element.Attribute("name").Value;
                var value = element.Element("value").Value;
                res.Add(key, value);
            }

            return res;
        }

        public List<string> Validar(string fichero)
        {
            var xelement = XElement.Load(fichero);
            var res = new List<string>();

            var elements = xelement.Elements("data");
            foreach (var element in elements)
            {
                var key = element.Attribute("name").Value;
                var value = element.Element("value").Value;
                if (string.IsNullOrEmpty(value))
                    res.Add(key);
            }

            return res;
        }
    }
}
