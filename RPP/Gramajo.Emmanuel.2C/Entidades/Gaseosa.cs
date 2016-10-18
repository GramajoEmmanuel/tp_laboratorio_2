using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    //[XmlType("Gaseosa")]
    public class Gaseosa : Producto
    {
        protected float _litros;
        protected bool DeConsumo;

        public  Gaseosa(int codigo, float precio, EMarcaProducto marca, float litros) : base(codigo, precio, marca)
        {
            this._litros = litros;
            this.DeConsumo = true;
        }
        private Gaseosa():base()
        {
            this.Tipo = ETipoProducto.Gaseosa;
        }
        public Gaseosa(Producto p, float litros) : this()
        {
            this.Tipo = ETipoProducto.Gaseosa;
            this._litros = litros;
        }
        public override float CalcularCostoDeProduccion
        {
            get { return (float) (base.Precio * 0.42); }
        }
        private string MostrarGaseosa()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Codigo: " + base._codDeBarras);
            sb.AppendLine("Marca: " + base._marca);
            sb.AppendLine("Precio: " + base._precio);
            sb.AppendLine("Litros: " + this._litros);
            return sb.ToString();
        }
        public override string ToString()
        {
            return MostrarGaseosa();
        }
        public override string Consumir()
        {
            return "Bebible";
        }
    }
}
