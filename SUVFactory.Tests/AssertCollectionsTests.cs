using SUVFactory.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SUVFactory.Tests
{
    public class AssertCollectionsTests
    {
        [Fact]
        public void HondaSUVFactory_Create_NaoPodeTerItemDeSerieSemDescricao()
        {
            //Arrange & Act
            var crv = HondaSUVFactory.CreateSUV(ModeloSUV.CRV, Versao.Touring);


            //Assert
            Assert.All(crv.ItensDeSerie, item => Assert.False(string.IsNullOrEmpty(item)));
        }

        [Fact]
        public void HondaSUVFactory_Create_CRVDeveTerItemSerieTetoSolar()
        {
            //Arrange & Act
            var crv = HondaSUVFactory.CreateSUV(ModeloSUV.CRV, Versao.Touring);


            //Assert
            Assert.Contains("Teto Solar", crv.ItensDeSerie);
        }

        [Fact]
        public void HondaSUVFactory_Create_WRVNaoDeveTerItemSerieTetoSolar()
        {
            //Arrange & Act
            var crv = HondaSUVFactory.CreateSUV(ModeloSUV.WRV, Versao.LX);


            //Assert
            Assert.DoesNotContain("Teto Solar", crv.ItensDeSerie);
        }


        [Fact]
        public void HondaSUVFactory_Create_CRVDevePossuirItensDeSerie()
        {
            //Arrange
            var itensSerie = new List<string>
            {
                "Bancos de Couro",
                "Start/ Stop Engine",
                "Sensor de Estacionamento",
                "Camera de Ré",
                "Multimidia Android Auto e Apple CarPlay",
                "Cruise Control",
                "Botão ECON",
                "Sensor de chuva",
                "Porta malas Hands-free",
                "Retrovisores com rebatimento",
                "Teto Solar"
            };

            //Act
            var crv = HondaSUVFactory.CreateSUV(ModeloSUV.CRV, Versao.Touring);

            //Assert
            Assert.Equal(itensSerie, crv.ItensDeSerie);
        }

    }

}
