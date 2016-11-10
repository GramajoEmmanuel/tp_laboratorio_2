using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Excepciones;


namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Enum
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion

        #region Atributos
        private string _nombre;
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        #endregion

        #region Constructores
        public Persona() { }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this._dni = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Propiedades
        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = ValidarNombreYApellido(value); }
        }
        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = ValidarNombreYApellido(value); }
        }
        public int Dni
        {
            get { return this._dni; }
            set { this._dni = ValidarDni(this._nacionalidad, value); }
        }
        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }
        public string StringToDNI
        {
            set
            {
                try
                {
                    this._dni = ValidarDni(this.Nacionalidad, value);
                }
                catch (Exception)
                {
                    throw new NacionalidadInvalidaException();
                }
            }
        }
        #endregion

        #region Metodos y Validaciones
        
        /// <summary>
        /// Se deberá validar que el DNI sea correcto, teniendo en cuenta su nacionalidad. Argentino entre 1 y
        ///89999999. Caso contrario, se lanzará la excepción DniInvalidoException
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            bool dni = false;
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                        dni = true;
                    break;
                case ENacionalidad.Extranjero:
                    if (dato < 90000000 || dato > 99999999)
                        dni = true;
                    break;
                default:
                    throw new NacionalidadInvalidaException("Nacionalidad invalida");
            }

            if (dni)
                throw new DniInvalidoException("Dni es invalido");
            else
                return dato;
        }
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            try
            {
                return ValidarDni(nacionalidad, int.Parse(dato));
            }
            catch (FormatException)
            {
                throw new DniInvalidoException();
            }
        }
        /// <summary>
        /// Validará que los nombres sean cadenas con caracteres válidos para nombres. Caso contrario, no se
        /// cargará.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private string ValidarNombreYApellido(string x)
        {
            Regex reg = new Regex("^[A-Za-z]+$");
            if (reg.IsMatch(x))
            {
                return x;
            }
            return "";
        }
        /// <summary>
        /// ToString retornará los datos de la Persona.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NOMBRE COMPLETO: " + this._apellido + ", " + this._nombre);
            sb.AppendLine("NACIONALIDAD: " + this._nacionalidad);
            return sb.ToString();
        }
        #endregion
    }
}
