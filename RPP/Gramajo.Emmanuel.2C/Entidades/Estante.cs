using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable]
    public class Estante
    {
        #region Atributos
        protected List<Producto> _productos;

        protected int _capMaxima;
        #endregion

        #region Propiedades
        
        private Estante()
        {
            this._productos = new List<Producto>();
        }
        
        public Estante(int capMaxima):this()
        {
            this._capMaxima = capMaxima;
        }
        
        public List<Producto> GetProductos()
        {
            return this._productos;
        }

        /// <summary>
        /// La propiedad pública ValorEstanteTotal está asociada a la sobrecarga privada y de instancia del método GetValorEstante.
        /// </summary>
        [XmlAttribute("Valor Del Estante")]
        public float ValorEstanteTotal
        {
            get
            {
                return GetValorEstante();
            }
        }
        #endregion

        #region Metodos

        /// <summary>
        /// El método público de clase MostrarEstante, retornará una cadena con toda la información del estante, incluyendo el detalle de cada uno de sus productos.
        /// </summary>
        /// <param name="es"></param>
        /// <returns></returns>
        public static string MostrarEstante(Estante es)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Producto p in es._productos)
            {
                sb.AppendLine(p.ToString());
            }

            return sb.ToString();
        }
        /// <summary>
        /// Método público y de instancia GetValorEstante, retornará el valor del estante de acuerdo con el enumerado que recibe como parámetro.
        /// </summary>
        public float GetValorEstante(Producto.ETipoProducto tipo)
        {
            float precio = 0;
            foreach (Producto p in _productos)
            {
                if (p.Tipo == tipo)
                {
                    precio += p.Precio;

                }
            }
            return precio;

        }

        /// <summary>
        /// Sobrecarga privada y de instancia del método GetValorEstante
        /// </summary>
        /// <returns></returns>
        private float GetValorEstante()
        {
            float precio = 0;
            foreach (Producto p in _productos)
            {
                precio += p.Precio;

            }
            return precio;
        }

        /// <summary>
        /// Realizar un método llamado SerializarEstante, estático y de clase. El método deberá guardar en un archivo XML toda la información del estante y sus productos.
        /// </summary>
        /// <param name="es"></param>

        public static void SerializarEstante(List<Producto> pr, string nombre)
        {
            try
            {
                Type[] Productos = { typeof(Harina), typeof(Gaseosa), typeof(Jugo), typeof(Galletita) };

                string NomArch = "\\salida.xml";

                if (nombre != "")
                {
                    NomArch = nombre;
                }

                StreamWriter escritor = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory  + NomArch);
                XmlSerializer serializa = new XmlSerializer(typeof(List<Producto>), Productos);

                serializa.Serialize(escritor, pr);
                escritor.Close();
                
            }
            catch (Exception ex)
            {
                
            }

        }

        //Esta parte no se si esta bien armada, pero no logre que me muestre la deserializacion
        
        //public static void DeserializarEstante()
        //{
        //    try
        //    {
        //        XmlSerializer serializa = new XmlSerializer(typeof(List<Producto>));
        //        StreamReader nomReader = new StreamReader("estante1.xml");
        //        Estante es = (Estante)serializa.Deserialize(nomReader);

        //        
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //}

        //public static void GuardarEstante(Estante es)
        //{
        //    List<string> _archivoDeTexto = new List<string>();

        //    File.WriteAllLines("Productos.txt", _archivoDeTexto.ToArray());
        //}


        #endregion

        #region Sobrecargas

        /// <summary>
        /// Igualdad, retornará true, si es que el producto ya se encuentra en el estante, false, caso contrario.
        /// </summary>
        /// <param name="pr"></param>
        /// <param name="es"></param>
        /// <returns></returns>
        public static bool operator ==(Producto pr, Estante es)
        {
            foreach (Producto p in es._productos)
            {
                if (p == pr)
                    return true;
            }

            return false;
        }


        public static bool operator !=(Producto pr, Estante es)
        {
            return !(pr == es);
        }

        /// <summary>
        /// Adición, retornará true, si el estante posee capacidad de almacenar al menos un producto más y dicho producto no se encuentra en el estante, false, caso contrario.Reutilizar código.
        /// </summary>
        /// <param name="es"></param>
        /// <param name="pr"></param>
        /// <returns></returns>
        public static bool operator +(Estante es, Producto pr)
        {
            if (es._productos.Count() < es._capMaxima)
            {
                foreach (Producto p in es._productos)
                {
                    if (p == pr)
                    {
                        return false;
                    }
                } 

                es._productos.Add(pr);
                return true;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Sustracción (Estante, Producto), retornará un estante sin el producto, siempre y cuando el producto se encuentre en el listado.
        /// </summary>
        /// <param name="es"></param>
        /// <param name="pr"></param>
        /// <returns></returns>
        public static Estante operator -(Estante es, Producto pr)
        {
                foreach (Producto p in es._productos)
                {
                    if (p == pr)
                    {
                    es._productos.Remove(pr);
                    return es;
                    }
                }
           
                return es;
        }

        /// <summary>
        /// Sustracción (Estante, ETipoProducto), retornará un estante con todos los productos menos el que coincida con el enumerado que recibe como parámetro.
        /// </summary>
        /// <param name="es"></param>
        /// <param name="pr"></param>
        /// <returns></returns>
        public static Estante operator -(Estante es, Producto.ETipoProducto pr)
        {
            foreach (Producto p in es._productos)
            {
                if (p.Tipo == pr)
                {
                    es._productos.Remove(p);
                    return es;
                }
            }
            return es;
        }
        #endregion

    }
}






