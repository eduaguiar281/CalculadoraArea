using SUVFactory.Veiculos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SUVFactory.Factories
{
    public enum ModeloSUV { CRV, HRV, WRV };

    public enum Versao { LX, EX, EXL, Touring }

    public class HondaSUVFactory
    {
        public static Veiculo CreateSUV(ModeloSUV modelo, Versao versao)
        {
            switch (modelo)
            {
                case ModeloSUV.CRV:
                    return CreateCRV(versao);
                case ModeloSUV.HRV:
                    return CreateHRV(versao);
                case ModeloSUV.WRV:
                    return CreateWRV(versao);
                default: 
                    return default;
            }
        }
        private static SUVGrande CreateCRV(Versao versao)
        {
            if (versao != Versao.Touring)
                throw new HondaFactoryException($"A Honda não fabrica esta versao '{versao}' para CR-V");
            var result = new SUVGrande("Honda", "CR-V", $"{versao}");
            result.AtualizaCombustivel(TipoCombustivel.Gasolina);
            result.AtualizaCambio(TipoCambio.CVT);
            result.AtualizaValor(209000);
            result.AtualizaItensDeSerie(new List<string>
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
            });
            result.AtualizarHomePage("https://www.honda.com.br/automoveis/crv");
            return result;
        }
        private static SUVMedio CreateHRV(Versao versao)
        {
            if (versao == Versao.EX)
                throw new HondaFactoryException($"A Honda não fabrica esta versao '{versao}' para HR-V");
            var result = new SUVMedio("Honda", "HR-V", $"{versao}");
            result.AtualizaCombustivel(TipoCombustivel.Flex);
            result.AtualizaCambio(TipoCambio.CVT);
            result.AtualizaItensDeSerie(ObterItensSerieHRV(versao));
            result.AtualizaValor(ObterValorHrv(versao));
            result.AtualizarHomePage("https://www.honda.com.br/automoveis/hrv");
            return result;
        }
        private static SUVCompacto CreateWRV(Versao versao)
        {
            if (versao == Versao.Touring)
                throw new HondaFactoryException($"A Honda não fabrica esta versao '{versao}' para WR-V");
            var result = new SUVCompacto("Honda", "WR-V", $"{versao}");
            result.AtualizaCombustivel(ObterTipoCombustivelWRV(versao));
            result.AtualizaCambio(ObterTipoCambioWRV(versao));
            result.AtualizaItensDeSerie(ObterItensSerieWRV(versao));
            result.AtualizaValor(ObterValorWrv(versao));
            result.AtualizarHomePage("https://www.honda.com.br/automoveis/wrv");
            return result;
        }
        private static double ObterValorHrv(Versao versao)
        {
            switch (versao)
            {
                case Versao.LX:
                    return 109000;
                case Versao.EXL:
                    return 142000;
                case Versao.Touring:
                    return 165000;
                default:
                    throw new HondaFactoryException($"A Honda não fabrica esta versao '{versao}' para HR-V");
            }
        }
        private static IList<string> ObterItensSerieHRV(Versao versao)
        {
            switch (versao)
            {
                case Versao.LX:
                    return new List<string>
                    {
                        "Bancos de Couro",
                        "Botão ECON",
                        "Teto Solar"
                    };
                case Versao.EXL:
                    return new List<string>
                    {
                        "Bancos de Couro",
                        "Botão ECON",
                        "Teto Solar",
                        "Multimidia Android Auto e Apple CarPlay",
                        "Cruise Control"
                    };
                case Versao.Touring:
                    return new List<string>
                    {
                        "Bancos de Couro",
                        "Botão ECON",
                        "Teto Solar",
                        "Multimidia Android Auto e Apple CarPlay",
                        "Cruise Control",
                        "Sensor de chuva",
                        "Retrovisores com rebatimento",
                        "Camera de Ré"
                    };
                default:
                    throw new HondaFactoryException($"A Honda não fabrica esta versao '{versao}' para HR-V");
            }
        }
        private static double ObterValorWrv(Versao versao)
        {
            switch (versao)
            {
                case Versao.LX:
                    return 69000;
                case Versao.EX:
                    return 89000;
                case Versao.EXL:
                    return 103000;
                default:
                    throw new HondaFactoryException($"A Honda não fabrica esta versao '{versao}' para WR-V");
            }
        }
        private static TipoCombustivel ObterTipoCombustivelWRV(Versao versao)
        {
            if (versao == Versao.Touring)
                throw new HondaFactoryException($"A Honda não fabrica esta versao '{versao}' para WR-V");
            switch (versao)
            {
                case Versao.EX:
                case Versao.LX:
                    return TipoCombustivel.Flex;
                case Versao.EXL:
                    return TipoCombustivel.Hibrido;
                default: throw new HondaFactoryException($"A Honda não fabrica esta versao '{versao}' para WR-V");
            }
        }
        private static TipoCambio ObterTipoCambioWRV(Versao versao)
        {
            if (versao == Versao.Touring)
                throw new HondaFactoryException($"A Honda não fabrica esta versao '{versao}' para WR-V");
            switch(versao)
            {
                case Versao.LX:
                    return TipoCambio.Manual;
                case Versao.EX:
                case Versao.EXL:
                    return TipoCambio.CVT;
                default: throw new HondaFactoryException($"A Honda não fabrica esta versao '{versao}' para WR-V");
            }
        }
        private static IList<string> ObterItensSerieWRV(Versao versao)
        {
            switch (versao)
            {
                case Versao.LX:
                    return new List<string>
                    {
                        "Botão ECON",
                    };
                case Versao.EX:
                    return new List<string>
                    {
                        "Bancos de Couro",
                        "Botão ECON",
                    };
                case Versao.EXL:
                    return new List<string>
                    {
                        "Bancos de Couro",
                        "Botão ECON",
                        "Teto Solar",
                        "Multimidia Android Auto e Apple CarPlay",
                        "Retrovisores com rebatimento",
                    };
                default:
                    throw new HondaFactoryException($"A Honda não fabrica esta versao '{versao}' para HR-V");
            }
        }
    }

    public class HondaFactoryException: Exception
    {
        public HondaFactoryException(string message)
            :base(message)
        { }
    }
}
