using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    [Serializable]
    public class Instructor:PersonaGimnasio
    {
        #region Atributos
        private Queue<Gimnasio.EClases> _clasesDelDia;
        private static Random _random;
        #endregion

        #region Constructores
        public Instructor()
        {
        }
        /// <summary>
        /// Se inicializará a random sólo en un constructor.
        /// </summary>
        static Instructor()
        {
            Instructor._random = new Random();
        }
        /// <summary>
        /// En el constructor de instancia se inicializará ClasesDelDia y se asignarán dos clases al azar al
        /// instructor mediante el método _randomClases.Las dos clases pueden o no ser la misma.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();
            this._randomClases();
        }
        #endregion

        #region Metodos
        private void _randomClases()
        {
            this._clasesDelDia.Enqueue((Gimnasio.EClases)Instructor._random.Next(3));
            this._clasesDelDia.Enqueue((Gimnasio.EClases)Instructor._random.Next(3));
        }
        /// <summary>
        /// ParticiparEnClase retornará la cadena "CLASES DEL DÍA " junto al nombre de la clases que da.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DÍA:");
            foreach (Gimnasio.EClases item in this._clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
        /// <summary>
        /// Sobreescribirá el método MostrarDatos con todos los datos del alumno.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// ToString hará públicos los datos del Instructor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Un Instructor será igual a un EClase si da esa clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Instructor i, Gimnasio.EClases clase)
        { 
            foreach (Gimnasio.EClases item in i._clasesDelDia)
            {
                if (item == clase)
                    return true;
            }

            return false;
        }
        public static bool operator !=(Instructor i, Gimnasio.EClases clase)
        {
            return !(i == clase);
        }

        #endregion
    }
}
