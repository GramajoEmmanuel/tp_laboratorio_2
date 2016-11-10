using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        private XmlSerializer _serializer;
        private string _path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
        public Xml()
        {
            this._serializer = new XmlSerializer(typeof(T));
        }

        public bool Guardar(string archivo, T datos)
        {
            try
            {
                using (XmlTextWriter textWriter = new XmlTextWriter(this._path + archivo, Encoding.UTF8))
                {
                    this._serializer.Serialize(textWriter, datos);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Leer(string archivo, out T datos)
        {
            try
            {
                using (XmlTextReader textReader = new XmlTextReader(this._path + archivo))
                {
                    datos = (T)this._serializer.Deserialize(textReader);
                    return true;
                }
            }
            catch (Exception ex)
            {
                datos = default(T);
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
