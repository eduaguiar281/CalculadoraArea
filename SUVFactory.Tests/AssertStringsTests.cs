using SUVFactory.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SUVFactory.Tests
{
    public class AssertStringsTests
    {

        public AssertStringsTests()
        {

        }

        [Fact(DisplayName = "Verificar Nome WR-V - LX")]
        [Trait("Tipo", "Honda SUV Factory")]
        public void HondaSUVFactory_CreateWrvLx_DeveRetornarNomeCorreto()
        {
            //Arrange 
            var suv = HondaSUVFactory.CreateSUV(ModeloSUV.WRV, Versao.LX);

            //Act

            var nomeSuv = suv.ToString();

            //Assert
            Assert.Equal("Honda WR-V - LX", nomeSuv);

        }

        [Fact(DisplayName = "Ignorando Case")]
        [Trait("Tipo", "Honda SUV Factory")]
        public void HondaSUVFactory_Create_NomeDeveIgnorarCase()
        {
            //Arrange 
            var suv = HondaSUVFactory.CreateSUV(ModeloSUV.WRV, Versao.LX);

            //Act

            var nomeSuv = suv.ToString();

            //Assert
            Assert.Equal("HONDA WR-V - LX", nomeSuv, true);
        }

        [Fact(DisplayName = "ToString deve começar com Honda")]
        [Trait("Tipo", "Honda SUV Factory")]
        public void HondaSUVFactory_Create_NomeDeveComecarComHonda()
        {
            //Arrange 
            var suv = HondaSUVFactory.CreateSUV(ModeloSUV.HRV, Versao.Touring);

            //Act

            var nomeSuv = suv.ToString();

            //Assert
            Assert.StartsWith("Honda", nomeSuv);

        }

        [Fact(DisplayName = "ToString deve terminar com Versão")]
        [Trait("Tipo", "Honda SUV Factory")]
        public void HondaSUVFactory_Create_NomeDeveTerminarComVersao()
        {
            //Arrange 
            var suv = HondaSUVFactory.CreateSUV(ModeloSUV.HRV, Versao.EXL);

            //Act

            var nomeSuv = suv.ToString();

            //Assert
            Assert.EndsWith(Versao.EXL.ToString(), nomeSuv);

        }

        [Fact(DisplayName = "Home Page Deve Ser Válida")]
        [Trait("Tipo", "Honda SUV Factory")]
        public void HondaSUVFactory_Create_HomePageDeveSerValida()
        {
            //Arrange && Act
            var suv = HondaSUVFactory.CreateSUV(ModeloSUV.CRV, Versao.Touring);


            //Assert
            Assert.Matches(@"[(http(s)?):\/\/(www\.)?a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)",
                suv.HomePage);

        }
    }
}
