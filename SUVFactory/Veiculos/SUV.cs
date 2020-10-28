using System;
using System.Collections.Generic;
using System.Text;

namespace SUVFactory.Veiculos
{
    public abstract class SUV: Veiculo
    {
        public SUV(string fabrica, string modelo, string versao)
            :base(fabrica, modelo, versao)
        { }
    }
}
