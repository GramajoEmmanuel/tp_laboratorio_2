using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    [Serializable]
    public sealed class Alumno:PersonaGimnasio
    {
        #region Enums
        public enum EEstadoCuenta { MesPrueba, AlDia, Deudor }
        #endregion

        #region Atributos
        public Gimnasio.EClases _claseQueToma;
        public EEstadoCuenta _estadoCuenta;
        #endregion

        #region Constructores
        public Alumno()
        {
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases clasesQueToma, EEstadoCuenta estadoCuenta):this(id, nombre, apellido, dni, nacionalidad, clasesQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Sobreescribirá el método MostrarDatos con todos los datos del alumno.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder(base.MostrarDatos());
            sb.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta);
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// ParticiparEnClase retornará la cadena "TOMA CLASE DE " junto al nombre de la clase que toma.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this._claseQueToma;
        }
        /// <summary>
        /// ToString hará públicos los datos del Alumno.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
        /// </summary>
        /// <param name="alumno"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno alumno, Gimnasio.EClases clase)
        {
            if (!object.ReferenceEquals(alumno, null))
                return (alumno._estadoCuenta != EEstadoCuenta.Deudor && alumno._claseQueToma == clase);
            return false;
        }
        /// <summary>
        /// Un Alumno será disntito a un EClase sólo si no toma esa clase.
        /// </summary>
        /// <param name="alumno"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno alumno, Gimnasio.EClases clase)
        {
            return !(alumno == clase);
        }
        #endregion
    }
}
