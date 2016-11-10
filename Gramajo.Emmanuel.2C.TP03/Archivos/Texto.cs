using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string _path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(this._path + archivo, true))
                {
                    sw.WriteLine(datos);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Leer(string archivo, out string datos)
        {
            try
            {
                using (StreamReader sr = new StreamReader(this._path + archivo, true))
                {
                    datos = sr.ReadToEnd();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                datos = "";
                return false;
            }
        }
    }
}
