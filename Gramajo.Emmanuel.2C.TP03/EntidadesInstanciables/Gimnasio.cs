using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Archivos;
using Excepciones;
namespace EntidadesInstanciables
{
    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Instructor))]
    [XmlInclude(typeof(Jornada))]
    public class Gimnasio
    {
        #region Enums
        public enum EClases { CrossFit = 0, Natacion = 1, Pilates = 2, Yoga = 3 };
        #endregion

        #region Atributos
        public List<Alumno> _alumnos;
        public List<Instructor> _instructores;
        public List<Jornada> _jornadas;
        #endregion

        #region Constructores
        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornadas = new List<Jornada>();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Se accederá a una Jornada específica a través de un indexador.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get { return this._jornadas[i]; }
        }
        #endregion

        #region Metodos Y Sobrecargas
        /// <summary>
        /// MostrarDatos será privado y de clase. Los datos del Gimnasio se harán públicos mediante ToString.
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        private static string MostrarDatos(Gimnasio g)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada item in g._jornadas)
            {
                sb.Append(item);
            }
            return sb.ToString();
        }
        /// <summary>
        /// Guardar de clase serializará los datos del Gimnasio en un XML, incluyendo todos los datos de sus
        /// Instructores, Alumnos y Jornadas.
        /// </summary>
        /// <param name="Gim"></param>
        /// <returns></returns>
        public static bool Guardar(Gimnasio Gim)
        {
            Xml<Gimnasio> datosXml = new Xml<Gimnasio>();
            return datosXml.Guardar("Gimnasio.xml", Gim);

        }
        /// <summary>
        /// Leer de clase retornará un Gimnasio con todos los datos previamente serializados.
        /// </summary>
        /// <param name="Gim"></param>
        /// <returns></returns>
        public static Gimnasio Leer(Gimnasio Gim)
        {
            Xml<Gimnasio> datos = new Xml<Gimnasio>();
            Gimnasio datosGimnasio;
            datos.Leer("Gimnasio.xml", out datosGimnasio);
            return datosGimnasio;
        }
        /// <summary>
        /// Un Gimnasio será igual a un Alumno si el mismo está inscripto en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Gimnasio g, Alumno a)
        {
            if (!object.ReferenceEquals(g, null))
                return g._alumnos.Any(unAlumno => unAlumno == a);

            return false;
        }
        /// <summary>
        /// Un Gimnasio será igual a un Instructor si el mismo está dando clases en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Gimnasio g, Instructor i)
        {
            if (!object.ReferenceEquals(g, null))
                return g._instructores.Any(item => item == i);

            return false;
        }
        /// <summary>
        /// La igualación entre un Gimnasio y una Clase retornará el primer instructor capaz de dar esa clase.
        /// Sino, lanzará la Excepción SinInstructorException.El distinto retornará el primer Instructor que no
        /// pueda dar la clase.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Instructor operator ==(Gimnasio g, EClases clase)
        {
            Instructor iDisponible = g._instructores.FirstOrDefault(item => item == clase);

            if (!Object.Equals(iDisponible, null))
                return iDisponible;
            else
                throw new SinInstructorException();
        }
        public static Instructor operator !=(Gimnasio g, EClases clase)
        {
            return g._instructores.FirstOrDefault(item => item != clase);
        }
        public static bool operator !=(Gimnasio g, Alumno a)
        {
            return !(g == a);
        }
        public static bool operator !=(Gimnasio g, Instructor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// Se agregarán Alumnos e Instructores mediante el operador +, validando que no estén previamente
        /// cargados.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Gimnasio operator +(Gimnasio g, Alumno a)
        {
            if (g != a)
                g._alumnos.Add(a);
            else
                throw new AlumnoRepetidoException();

            return g;
        }
        public static Gimnasio operator +(Gimnasio g, Instructor i)
        {
            if (g != i)
                g._instructores.Add(i);
            return g;
        }
        /// <summary>
        /// Al agregar una clase a un Gimnasio se deberá generar y agregar una nueva Jornada indicando la
        /// clase, un Instructor que pueda darla(según su atributo ClasesDelDia) y la lista de alumnos que la
        /// toman(todos los que coincidan en su campo ClaseQueToma).
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Gimnasio operator +(Gimnasio g, EClases clase)
        {
            try
            {
                Jornada jornada = new Jornada(clase, g == clase);

                foreach (Alumno item in g._alumnos.Where(item => item == clase))
                {
                    jornada._alumnos.Add(item);
                }

                g._jornadas.Add(jornada);
                return g;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public override string ToString()
        {
            return Gimnasio.MostrarDatos(this);
        }
        #endregion
    }
}
