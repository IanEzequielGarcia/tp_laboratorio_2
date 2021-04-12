using System;

namespace Entidades
{
    public static class Calculadora
    {
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
        static private string ValidarOperador(char operador)
        {
            if (operador == '/' || operador == '*' || operador == '-')
                return $"{operador}";
            else
                return "+";
        }
    }
    public class Numero
    {
        private double number;
        
        public Numero()
        {
            this.number = 0;
        }
        public Numero(double ingresado):this(string.Format("{0}", ingresado))
        {

        }
        public Numero(string ingresado)
        {
            SetNumero = ingresado;
        }
        private double ValidarNumero(string ingresado)
        {
            double aux;
            if (!double.TryParse(ingresado, out aux))
                return 0;
            return aux;
        }
        private string SetNumero
        {
            set { this.number = ValidarNumero(value); }
        }
        bool EsBinario(string elnumero)
        {
            for(int i=0;i<elnumero.Length;i++)
            {
                if (elnumero[i] != '1'&& elnumero[i] != '0')
                    return false;  
            }
            return true;
        }
        string DecimalBinario(double elNumero)
        {
            return "";
        }
        string BinarioDecimal(string elNumero)
        {
            return "";
        }
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.number - n2.number;
        }
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.number + n2.number;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.number * n2.number;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            if (n1.number != 0 && n2.number != 0)
                return n1.number / n2.number;
            else
                return double.MinValue;
        }
    }
}
