using System;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Toma el string operador que contiene el calculo aritmetico deseado, y lo lleva a cabo con los objetos Numero1 y Numero2
        /// </summary>
        /// <param name="n1">el primer numero</param>
        /// <param name="n2">el segundo numero</param>
        /// <param name="operador">el operador ingresado</param>
        /// <returns>el resultado de la operacion aritmetica</returns>
        public static double Operador(Numero n1,Numero n2,string operador)
        {
            
            if (!String.IsNullOrWhiteSpace(operador))
                operador=ValidarOperador(operador.Trim()[0]);
            switch(operador)
            {
                case "/":
                    return n1 / n2;
                case "*":
                    return n1 * n2;
                case "-":
                    return n1 - n2;
                default:
                    return n1 + n2;
            }
        }
        /// <summary>
        /// Valida que el operador ingresado sea correcto (+ - * /), y de no ser así, devuelve +
        /// </summary>
        /// <param name="operador">el operador ingresado</param>
        /// <returns>devuelve el operador ingresado, y de default + </returns>
        static private string ValidarOperador(char operador)
        {
            if (operador == '/' || operador == '*' || operador == '-')
                return $"{operador}";
            else
                return "+";
        }
    }
    
}
