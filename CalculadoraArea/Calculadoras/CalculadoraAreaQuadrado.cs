using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraArea.Calculadoras
{
    public class CalculadoraAreaQuadrado : CalculadoraAreaBase
    {
        public CalculadoraAreaQuadrado(double lado)
        {
            Lado = lado;

        }

        public double Lado { get; private set; }
        public override void Calcular()
        {
            if (Lado < 0)
                throw new ArgumentException("Valor do Lado não pode ser menor que zero");

            Resultado = Math.Pow(Lado, 2);
        }
    }
}
