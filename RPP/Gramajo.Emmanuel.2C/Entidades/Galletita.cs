using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Galletita: Producto
    {
        protected float _peso;
        protected bool DeConsumo;

        private Galletita()
        {
            this.Tipo = ETipoProducto.Galletita;
        }
        public Galletita(int codigo, float precio, EMarcaProducto marca,  float peso) : base(codigo, precio, marca)
        {
            this.Tipo = ETipoProducto.Galletita;
            this._peso = peso;
            this.DeConsumo = true;
        }

        public override float CalcularCostoDeProduccion
        {
            get { return (float)(base.Precio * 0.33); }
                
        }

        /// <summary>
        /// El método privado de clase MostrarGalletita, retornará una cadena conteniendo la
        /// información completa del objeto recibido por parámetro.
        /// </summary>
        /// <param name="galletita"></param>
        /// <returns></returns>
        private static string MostrarGalletita(Galletita galletita) 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Codigo: " + galletita._codDeBarras);
            sb.AppendLine("Marca: " + galletita._marca);
            sb.AppendLine("Precio: " + galletita._precio);
            sb.AppendLine("Peso: " + galletita._peso);
            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarGalletita(this);
        }

        public override string Consumir()
        {
            return "Comestible";
        }
    }
}