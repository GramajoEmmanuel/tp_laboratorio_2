using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{

    public class Harina: Producto
    {
        public enum ETipoHarina { CuatroCeros, Integral }
        private ETipoHarina _tipo;
        protected bool DeConsumo;

        private Harina()
        {
            this.Tipo = ETipoProducto.Harina;
        }

        public Harina(int codigo, float precio, EMarcaProducto marca, ETipoHarina tipo) : base(codigo, precio, marca)
        {
            this.Tipo = ETipoProducto.Harina;
            this._tipo = tipo;
            this.DeConsumo = false;
        }

        public override float CalcularCostoDeProduccion
        {
            get { return (float) (base.Precio*0.60); }
        }

        private string MostrarHarina()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Codigo: " + base._codDeBarras);
            sb.AppendLine("Marca: " + base._marca);
            sb.AppendLine("Precio: " + base._precio);
            sb.AppendLine("Tipo: " + this._tipo);
            return sb.ToString();
        }
        public override string ToString()
        {
            return MostrarHarina();
        }
    }
}
