using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    class CajaDeAhorro : CuentaBancaria
    {
        // CajaDeAhorro -> tipo = 1
        public CajaDeAhorro(string numero, decimal saldo, string[] titulares) : base(numero, saldo, 1, titulares)
        {

        }
    }
}
