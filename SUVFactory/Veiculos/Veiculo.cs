using System;
using System.Collections.Generic;
using System.Linq;

namespace SUVFactory.Veiculos
{
    public enum TipoCambio { Manual, CVT };
    public enum TipoCombustivel { Gasolina, Flex, Hibrido }

    public abstract class Veiculo
    {
        public Veiculo(string fabrica, string modelo, string versao)
        {
            Fabrica = fabrica;
            Modelo = modelo;
            Versao = versao;
            ItensDeSerie = new List<string>();
            Cambio = TipoCambio.Manual;
            Combustivel = TipoCombustivel.Gasolina;

        }

        public string Fabrica { get; protected set; }
        public string Modelo { get; protected set; }
        public string Versao { get; protected set; }
        public IList<string> ItensDeSerie { get; protected set; }
        public virtual void AtualizaItensDeSerie(IList<string> itensDeSerie)
        {
            if (itensDeSerie == null)
                throw new ArgumentNullException(nameof(itensDeSerie));
            ItensDeSerie = itensDeSerie;
        }

        public double Valor { get; protected set; }
        public virtual void AtualizaValor(double valor)
        {
            if (valor <= 0)
                throw new ArgumentException("Valor informado não pode ser menor ou igual a zero");
            Valor = valor;
        }

        public TipoCambio Cambio { get; protected set; }
        public virtual void AtualizaCambio(TipoCambio cambio)
        {
            Cambio = cambio;
        }

        public TipoCombustivel Combustivel { get; protected set; }
        public virtual void AtualizaCombustivel (TipoCombustivel combustivel)
        {
            Combustivel = combustivel;
        }

        public string HomePage { get; private set; }
        public virtual void AtualizarHomePage(string homePage)
        {
            HomePage = homePage;
        }

        public override string ToString()
        {
            return $"{Fabrica} {Modelo} - {Versao}";
        }

        public virtual string ObterItemSerie(string itemSerie)
        {
            return ItensDeSerie.FirstOrDefault(x => x.ToLower() == itemSerie.ToLower());
        }

        public virtual bool TemItemSerie(string opicional)
        {
            return !string.IsNullOrEmpty(ObterItemSerie(opicional));
        }

    }
}
