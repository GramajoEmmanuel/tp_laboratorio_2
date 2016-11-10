using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException :  Exception
    {
        private static string mensajeBase = "El dni es invalido";

        #region Constructores
        public DniInvalidoException():this(mensajeBase)
        {

        }
        public DniInvalidoException(Exception e) : this(mensajeBase, e)
        {
            
        }
        public DniInvalidoException(string message) : this(mensajeBase, null)
        {

        }
        public DniInvalidoException(string message, Exception e)
        {
            
        }
        #endregion
    }
}
