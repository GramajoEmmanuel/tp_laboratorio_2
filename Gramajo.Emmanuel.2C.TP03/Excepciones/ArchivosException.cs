using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException:Exception
    {
        private static string mensajeBase = "Algo salio mal";

        public ArchivosException(Exception innerException)
            : base(ArchivosException.mensajeBase, innerException)
        { }
    }
}
