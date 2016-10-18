using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
   
    [Serializable]
    public abstract class Producto
    {
        #region Enums
        public enum ETipoProducto { Galletita, Gaseosa, Harina, Jugo, Todos }
        public enum EMarcaProducto { Diversión, Favorita, Naranjú, Pitusas, Swift }
        #endregion

        #region Atributos
        private ETipoProducto _tipo;
        protected EMarcaProducto _marca;
        protected float _precio;
        protected int _codDeBarras;
        #endregion

        #region Constructores

        public Producto()
        {
            
        }
        public Producto(int codigo, float precio, EMarcaProducto marca)
        {
            this._marca = marca;
            this._precio = precio;
            this._codDeBarras = codigo;
        }
        #endregion

        #region Propiedades

        public EMarcaProducto Marca
        {
            get
            {
                return this._marca;
            }
            set
            {
                this._marca = value;
            }
        }

        
        public float Precio
        {
            get
            {
                return this._precio;
            }
            set { Precio = value; }
        }

        
        public abstract float CalcularCostoDeProduccion
        {
            get;
        }
        
        public ETipoProducto Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        
        public int Codigo
        {
            get
            {
              return _codDeBarras;
            }
            set { this._codDeBarras = value; }
        }

        #endregion

        #region Metodos
        private static string MostrarProducto(Producto p)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Codigo: " + p._codDeBarras);
            sb.AppendLine("Marca: " + p._marca);
            sb.AppendLine("Precio: " + p._precio);

            return sb.ToString();
        }

        public virtual string Consumir()
        {
            return "Parte de una mezcla";
        }
        #endregion

        #region Sobrecargas
        public static bool operator ==(Producto p1, Producto p2)
        {
            return (p1.Marca == p2.Marca && p1._codDeBarras == p2._codDeBarras);
        }

        public static bool operator !=(Producto p1, Producto p2)
        {
            return !(p1 == p2);
        }

        public static bool operator ==(Producto prod, EMarcaProducto marca)
        {
            if (prod._marca == marca)
                return true;

            return false;
        }

        public static bool operator !=(Producto prod, EMarcaProducto marca)
        {
            return !(prod == marca);
        }

        public static explicit operator int (Producto p)
        {
            return p._codDeBarras;
        }

        public static implicit operator string(Producto p)
        {
            return MostrarProducto(p);
        }

        public override bool Equals(Object obj)
        {
            return Marca.GetType() == obj.GetType();
        }
        
        #endregion

    }
}
