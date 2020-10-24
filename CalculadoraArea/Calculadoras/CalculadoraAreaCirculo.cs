using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraArea.Calculadoras
{
    public class CalculadoraAreaCirculo : CalculadoraAreaBase
    {
        public CalculadoraAreaCirculo(double raio)
        {
            Raio = raio;
        }

        public double Raio { get; private set; }

        public override void Calcular()
        {
            if (Raio < 0)
                throw new ArgumentException("Valor do Raio não pode ser menor que zero");
            Resultado = Math.PI * (Math.Pow(Raio, 2));
        }
    }
}
