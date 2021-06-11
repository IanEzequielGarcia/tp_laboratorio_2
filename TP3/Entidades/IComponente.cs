using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IComponente
    {
        #region propiedades 
        string Modelo { get; set; }
        float Hercio { get; set; }
        int Cores { get; set; }
        #endregion

        #region metodos
        void CalcularVelocidad();
        #endregion
    }
}
