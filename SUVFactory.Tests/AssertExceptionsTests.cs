using SUVFactory.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SUVFactory.Tests
{
    public class AssertExceptionsTests
    {
        [Fact]
        public void HondaSUVFactory_Create_DeveLancarExcecaoParaCrvExl()
        {
            //Arrange & Act & Assert

            Assert.Throws<HondaFactoryException>(() => HondaSUVFactory.CreateSUV(ModeloSUV.CRV, Versao.EXL));
        }


        [Fact]
        public void Veiculo_AtualizaValor_DeveLancarExcecaoParaValorAbaixoDeZero()
        {
            //Arrange 
            var veiculo = HondaSUVFactory.CreateSUV(ModeloSUV.CRV, Versao.Touring);

            //Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => veiculo.AtualizaValor(-100));

            Assert.Equal("Valor informado não pode ser menor ou igual a zero", ex.Message);
        }
    }
}
