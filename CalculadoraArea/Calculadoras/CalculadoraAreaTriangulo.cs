using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraArea.Calculadoras
{
    public class CalculadoraAreaTriangulo : CalculadoraAreaBase
    {
        public CalculadoraAreaTriangulo(double baseTriangulo, double altura)
        {

        }

        public double Base { get; private set; }
        public double Altura { get; private set; }

        public override void Calcular()
        {
            if (Base < 0)
                throw new ArgumentException("Valor do Base não pode ser menor que zero");
            if (Altura < 0)
                throw new ArgumentException("Valor do Altura não pode ser menor que zero");

            Resultado = ((Base * Altura) / 2);
        }


    }
}
