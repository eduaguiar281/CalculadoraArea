using CalculadoraArea.Calculadoras;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CalculadoraArea.Tests
{
    public class CalculadoraAreaCirculoTestes
    {
        [Fact]
        public void CalculadoraAreaCirculo_Calular_ResultadoDeveEstarCorreto()
        {
            //Arrange
            CalculadoraAreaCirculo calculadora = new CalculadoraAreaCirculo(15);

            //Act
            calculadora.Calcular();

            //Assert
            Assert.Equal(706.85834705770344, calculadora.Resultado);
        }

        [Fact]
        public void CalculadoraAreaCirculo_CalularRaioNegativo_DeveLancarExcecao()
        {
            //Arrange
            CalculadoraAreaCirculo calculadora = new CalculadoraAreaCirculo(-15);

            //Act
            Action act = () => calculadora.Calcular();

            //Act & Assert
            Assert.Throws<ArgumentException>(act);

        }

        [Theory]
        [InlineData(15, 706.85834705770344)]
        [InlineData(20, 1256.6370614359173)]
        [InlineData(12.35, 479.16356550714914)]
        [InlineData(3, 28.274333882308138)]
        [InlineData(4.5, 63.617251235193308)]
        public void CalculadoraAreaCirculo_Cacular_TeoriaDeveEstarCorreto(double raio, double resultado)
        {
            //Arrange
            CalculadoraAreaCirculo calculadora = new CalculadoraAreaCirculo(raio);

            //Act
            calculadora.Calcular();

            //Assert
            Assert.Equal(resultado, calculadora.Resultado);
        }


    }
}
