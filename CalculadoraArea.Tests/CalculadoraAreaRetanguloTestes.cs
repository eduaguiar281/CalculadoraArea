using CalculadoraArea.Calculadoras;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CalculadoraArea.Tests
{
    public class CalculadoraAreaRetanguloTestes
    {
        [Fact]
        public void CalculadoraAreaRetangulo_Cacular_ResultadoDeveEstarCorreto()
        {
            //Arrange
            CalculadoraAreaRetangulo calculadora = new CalculadoraAreaRetangulo(15, 5);

            //Act
            calculadora.Calcular();

            //Assert

            Assert.Equal(75, calculadora.Resultado);
        }

        [Fact]
        public void CalculadoraAreaRetangulo_CacularBaseNegativa_DeveLancarExcecao()
        {
            //Arrange
            CalculadoraAreaRetangulo calculadora = new CalculadoraAreaRetangulo(-6, 5);

            //Act
            Action act = () => calculadora.Calcular();

            //Assert
            var ex = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Valor do Base não pode ser menor que zero", ex.Message);
        }

        [Fact]
        public void CalculadoraAreaRetangulo_CacularAlturaNegativa_DeveLancarExcecao()
        {
            //Arrange
            CalculadoraAreaRetangulo calculadora = new CalculadoraAreaRetangulo(6, -5);

            //Act
            Action act = () => calculadora.Calcular();

            //Assert
            var ex = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Valor do Altura não pode ser menor que zero", ex.Message);
        }

        [Theory]
        [InlineData(15, 5, 75)]
        [InlineData(12.14, 3.5, 42.49000)]
        [InlineData(25, 8, 200)]
        [InlineData(43.88, 18.63, 817.48440)]
        [InlineData(18, 2, 36)]
        public void CalculadoraAreaRetangulo_Cacular_TeoriaDeveEstarCorreta(double baseRet, double altura, double resultado)
        {
            //Arrange
            CalculadoraAreaRetangulo calculadora = new CalculadoraAreaRetangulo(baseRet, altura);

            //Act
            calculadora.Calcular();

            //Assert

            Assert.Equal(resultado, calculadora.Resultado);
        }
    }
}
