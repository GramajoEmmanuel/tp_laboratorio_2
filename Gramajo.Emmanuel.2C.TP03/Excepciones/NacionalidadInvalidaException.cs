using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        #region Atributos
        private static string mensajeBase = "La nacionalidad no se coincide con el numero de DNI";
        #endregion

        #region Constructores
        public NacionalidadInvalidaException():this(mensajeBase)
        {
            
        }

        public NacionalidadInvalidaException(string msj) : base(msj)
        {
            
        }
        #endregion
    }
}
