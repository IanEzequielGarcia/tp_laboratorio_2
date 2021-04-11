using System;

namespace Entidades
{
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
            int elInt = elNumero;
            string binary = Convert.ToString(elInt, 2);

            return binary;
        }
    }
}
