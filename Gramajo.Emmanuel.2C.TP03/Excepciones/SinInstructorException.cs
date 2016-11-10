using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinInstructorException: Exception
    {
        private static string mensajeBase = "No hay instructor para la clase.";

        public SinInstructorException()
            : base(SinInstructorException.mensajeBase)
        { }
    }
}
