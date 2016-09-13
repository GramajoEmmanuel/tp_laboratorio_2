using System;
using System.Windows.Forms;

namespace Gramajo.Emmanuel._2C.TP01
{
    class Program
    {
        /// <summary>
        /// Entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
