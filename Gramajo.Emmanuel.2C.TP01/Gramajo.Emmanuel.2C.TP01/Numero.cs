using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gramajo.Emmanuel._2C.TP01
{
    class Numero
    {
        private double _numero;

        public Numero()
        {
            this._numero = 0;
        }
        public Numero(double numero)
        {
            this._numero = numero;
        }
        public Numero(string numero)
        {
            this.setNumero(numero);
        }

        public void setNumero(string numero)
        {
            if (this.validarNumero(numero) == 1)
            {
                this._numero = double.Parse(numero);
            }
        }

        public double getNumero()
        {
            return this._numero;
        }

        private double validarNumero(string numeroString)
        {
            if (double.TryParse(numeroString, out this._numero) == true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

    }
}
