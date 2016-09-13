using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gramajo.Emmanuel._2C.TP01
{
    class Calculadora
    {
        public static double operar(Numero numero1, Numero numero2, string operador)
        {
            double resultado = 0;
            switch (operador)
            {
                case "+":
                    resultado = numero1.getNumero() + numero2.getNumero();
                    break;
                case "-":
                    resultado = numero1.getNumero() - numero2.getNumero();
                    break;
                case "*":
                    resultado = numero1.getNumero() * numero2.getNumero();
                    break;
                case "/":
                    if (operador == "/" && (numero2.getNumero() == 0))
                    {
                        resultado = 0;
                    }
                    else
                    {
                        resultado = numero1.getNumero() / numero2.getNumero();
                    }
                    break;
            }
            return resultado;
        }

        public static string validarOperador(string operador)
        {
            if (operador != "-" && operador != "*" && operador != "/")
            {
                return "+";
            }
            else
            {
                return operador;
            }
        }
    }
}
