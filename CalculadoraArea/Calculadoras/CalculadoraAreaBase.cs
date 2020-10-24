using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraArea.Calculadoras
{
    public class CalculadoraAreaBase
    {
        public double Resultado { get; protected set; }
        public virtual void Calcular()
        {
            throw new NotImplementedException();
        }

    }
}
