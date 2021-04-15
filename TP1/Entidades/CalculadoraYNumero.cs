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
    public class Numero
    {
        private double number;
        /// <summary>
        /// constructor por defecto
        /// </summary>
        public Numero()
        {
            this.number = 0;
        }
        /// <summary>
        /// constructor con numero, que llama al constructor por string
        /// </summary>
        /// <param name="ingresado"></param>
        public Numero(double ingresado):this(string.Format("{0}", ingresado))
        {

        }
        /// <summary>
        /// constructor por string, llama a la propiedad SetNumero
        /// </summary>
        /// <param name="ingresado"></param>
        public Numero(string ingresado)
        {
            SetNumero = ingresado;
        }
        /// <summary>
        /// Valida que el string ingresado sea un numero valido
        /// </summary>
        /// <param name="ingresado">el string ingresado con el numero</param>
        /// <returns>el numero ya parseado de string a double</returns>
        private double ValidarNumero(string ingresado)
        {
            double aux;
            if (!double.TryParse(ingresado, out aux))
                return 0;
            return aux;
        }
        /// <summary>
        /// Valida que el string ingresado sea un numero valido y lo setea
        /// </summary>
        private string SetNumero
        {
            set { this.number = ValidarNumero(value); }
        }
        /// <summary>
        /// comprueba que el string ingresado sea binario
        /// </summary>
        /// <param name="elnumero">string ingresado</param>
        /// <returns>devuelve true si es un binario valido o false si no lo es</returns>
        bool EsBinario(string elnumero)
        {
            for(int i=0;i<elnumero.Length;i++)
            {
                if (String.IsNullOrWhiteSpace(elnumero) || elnumero[i] != '1'&& elnumero[i] != '0'||elnumero[0]=='-')
                    return false;  
            }
            return true;
        }
        /// <summary>
        /// convierte un numero double decimal en binario
        /// </summary>
        /// <param name="elNumero">el double a convertir en binario</param>
        /// <returns>si es valido devuelve el numero convertido a binario y si no lo es devuelve "Valor invalido"</returns>
        public string DecimalBinario(double elNumero)
        {
            Int64 aux2 = Convert.ToInt64(elNumero);
            if (aux2 >= 0)
                return Convert.ToString(aux2, 2);
            return "Valor inválido";
        }
        /// <summary>
        /// Convierte un numero binario guardado en un string a decimal
        /// </summary>
        /// <param name="elNumero">El numero a convertir</param>
        /// <returns>si es valido devuelve el numero convertido a decimal y si no lo es devuelve "Valor invalido"</returns>
        public string BinarioDecimal(string elNumero)
        {
            if (EsBinario(elNumero.ToString()))
                return Convert.ToString(Convert.ToInt64(elNumero, 2));
            return "Valor inválido";
        }
        /// <summary>
        /// resta los numeros guardados en n1 y n2
        /// </summary>
        /// <param name="n1">el numero a restar</param>
        /// <param name="n2">el numero que resta</param>
        /// <returns>el resultado de la resta</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.number - n2.number;
        }
        /// <summary>
        /// suma  los numeros guardados en n1 y n2
        /// </summary>
        /// <param name="n1">el primer numero a sumar</param>
        /// <param name="n2">el segundo numero a sumar</param>
        /// <returns>el resultado de la suma</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.number + n2.number;
        }
        /// <summary>
        /// multiplica los numeros guardados en n1 y n2
        /// </summary>
        /// <param name="n1">el primer numero a multiplicar</param>
        /// <param name="n2">el segundo numero a multiplicar</param>
        /// <returns>el resultado de la multiplicacion</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.number * n2.number;
        }
        /// <summary>
        /// divide los numeros guardados en n1 y n2
        /// </summary>
        /// <param name="n1">el dividendo</param>
        /// <param name="n2">el divisor</param>
        /// <returns>el resultado de la division,si se intenta dividir por 0 devuelte double.MinValue</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n1.number != 0 && n2.number != 0)
                return n1.number / n2.number;
            else
                return double.MinValue;
        }
    }
}
