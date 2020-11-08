using SUVFactory.Factories;
using SUVFactory.Veiculos;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SUVFactory.Tests
{
    public class AssertObjectType
    {
        [Theory]
        [InlineData(ModeloSUV.CRV, Versao.Touring)]
        [InlineData(ModeloSUV.HRV, Versao.LX)]
        [InlineData(ModeloSUV.WRV, Versao.EXL)]
        public void HondaSUVFactory_CreateCRV_DeveCriarTipoCorreto(ModeloSUV modelo, Versao versao)
        {
            //Arrange & Act
            var suv = HondaSUVFactory.CreateSUV(modelo, versao);

            //Asserts
            if (modelo == ModeloSUV.CRV)
                Assert.IsType<SUVGrande>(suv);
            if (modelo == ModeloSUV.HRV)
                Assert.IsType<SUVMedio>(suv);
            if (modelo == ModeloSUV.WRV)
                Assert.IsType<SUVCompacto>(suv);
        }

        [Theory]
        [InlineData(ModeloSUV.CRV, Versao.Touring)]
        [InlineData(ModeloSUV.HRV, Versao.LX)]
        [InlineData(ModeloSUV.WRV, Versao.EXL)]
        public void HondaSUVFactory_CreateCRV_DeveDerivarDeSUV(ModeloSUV modelo, Versao versao)
        {
            //Arrange & Act
            var suv = HondaSUVFactory.CreateSUV(modelo, versao);

            //Asserts
            Assert.IsAssignableFrom<SUV>(suv);
        }

    }
}
