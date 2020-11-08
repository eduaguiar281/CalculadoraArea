using SUVFactory.Factories;
using SUVFactory.Veiculos;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SUVFactory.Tests
{
    public class AssertRangesTests
    {
        [Theory]
        [InlineData(ModeloSUV.CRV, Versao.Touring)]
        [InlineData(ModeloSUV.HRV, Versao.LX)]
        [InlineData(ModeloSUV.WRV, Versao.EXL)]
        public void HondaSUVFactory_Create_FaixaDePrecoConformeModelo(ModeloSUV modelo, Versao versao)
        {
            //Arrange & Act
            var suv = HondaSUVFactory.CreateSUV(modelo, versao);

            if (suv is SUVCompacto)
                Assert.InRange(suv.Valor, 65000, 105000);
            if (suv is SUVMedio)
                Assert.InRange(suv.Valor, 106000, 170000);
            if (suv is SUVGrande)
                Assert.InRange(suv.Valor, 200000, double.MaxValue);

            Assert.NotInRange(suv.Valor, 0, 60000);
        }

    }
}
