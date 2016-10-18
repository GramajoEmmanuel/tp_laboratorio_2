using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    //[XmlType("Jugo")]
    public class Jugo : Producto
    {
        public enum ESaborJugo { Asqueroso, Pasable, Rico }
        #region Atributos
        protected ESaborJugo _sabor;
        protected bool DeConsumo;
        #endregion

        #region Constructores

        private Jugo()
        {
            this.Tipo = ETipoProducto.Jugo;
        }
        
        public Jugo(int codigo, float precio, EMarcaProducto marca, ESaborJugo sabor) :base(codigo, precio, marca)
        {
            this.Tipo = ETipoProducto.Jugo;
            this._sabor = sabor;
            this.DeConsumo = true;
        }
        #endregion

        #region Propiedades



        public override float CalcularCostoDeProduccion
        {
            get
            {
                return (float)(base.Precio * 0.40);
            }
        }

        #endregion

        #region Metodos

        private string MostrarJugo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Codigo: " + base._codDeBarras);
            sb.AppendLine("Marca: " + base._marca);
            sb.AppendLine("Precio: " + base._precio);
            sb.AppendLine("Sabor: " + this._sabor);
            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarJugo();
        }

        public override string Consumir()
        {
            return "Bebible";
        }


        #endregion


    }
}
