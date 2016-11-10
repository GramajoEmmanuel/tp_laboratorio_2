using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Archivos;
namespace EntidadesInstanciables
{
    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Instructor))]
    public class Jornada
    {
        #region Atributos
        public List<Alumno> _alumnos;
        public Gimnasio.EClases _clase;
        public Instructor _instructor;
        #endregion

        #region Constructores
        /// <summary>
        /// Se inicializará la lista de alumnos en el constructor por defecto.
        /// </summary>
        public Jornada()
        {
            this._alumnos = new List<Alumno>();
        }
        public Jornada(Gimnasio.EClases clase, Instructor instructor) : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }
        #endregion

        #region Metodos Y Sobrecargas
        /// <summary>
        /// Guardar de clase guardará los datos de la Jornada en un archivo de texto.
        /// </summary>
        /// <param name="j"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada j)
        {
            Texto _tex = new Texto();
            return _tex.Guardar("Jornada.txt", j.ToString());
        }
        /// <summary>
        /// Leer de clase retornará los datos de la Jornada como texto.
        /// </summary>
        /// <param name="j"></param>
        /// <returns></returns>
        public static string Leer(Jornada j)
        {
            string datos = "";
            Texto tex = new Texto();
            tex.Leer("Jornada.txt", out datos);
            return datos;
        }
        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            if (j != null)
                foreach (Alumno item in j._alumnos)
                {
                    if (item == a)
                        return true;
                }

            return false;
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Agregar Alumnos a la clase por medio del operador +, validando que no estén previamente
        /// cargados.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j._alumnos.Add(a);

            return j;
        }
        /// <summary>
        /// ToString mostrará todos los datos de la Jornada.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            sb.AppendLine("CLASE DE " + this._clase + " POR " + this._instructor);
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno item in this._alumnos)
            {
                sb.Append(item);
            }
            sb.AppendLine("<------------------------------------------------>");

            return sb.ToString();
        }
        #endregion
    }
}