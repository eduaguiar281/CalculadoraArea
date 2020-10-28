using SUVFactory.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SUVFactory.Tests
{
    public class AssertBooleansAndNullsTests
    {
        [Fact]
        public void HondaSUVFactory_Create_TodosModelosDevemTerBotaoEcon()
        {
            //Arrange
            string itemSerie = "Botão ECON";
            
            //Act
            var crv = HondaSUVFactory.CreateSUV(ModeloSUV.CRV, Versao.Touring);
            var hrv = HondaSUVFactory.CreateSUV(ModeloSUV.HRV, Versao.LX);
            var wrv = HondaSUVFactory.CreateSUV(ModeloSUV.WRV, Versao.LX);

            //Assert
            Assert.True(crv.TemItemSerie(itemSerie));
            Assert.NotNull(crv.ObterItemSerie(itemSerie));
            Assert.True(hrv.TemItemSerie(itemSerie));
            Assert.NotNull(hrv.ObterItemSerie(itemSerie));
            Assert.True(wrv.TemItemSerie(itemSerie));
            Assert.NotNull(wrv.ObterItemSerie(itemSerie));
        }

        [Fact]
        public void HondaSUVFactory_Create_WrvLxExNaoDeveTerTetoSolar()
        {
            //Arrange
            string itemSerie = "Teto Solar";

            //Act
            var ex = HondaSUVFactory.CreateSUV(ModeloSUV.WRV, Versao.EX);
            var lx = HondaSUVFactory.CreateSUV(ModeloSUV.WRV, Versao.LX);

            //Assert

            Assert.Null(ex.ObterItemSerie(itemSerie));
            Assert.False(ex.TemItemSerie(itemSerie));
            Assert.Null(lx.ObterItemSerie(itemSerie));
            Assert.False(lx.TemItemSerie(itemSerie));
        }
    }
}
