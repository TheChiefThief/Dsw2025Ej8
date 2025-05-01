using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    public class CuentaCorriente : CuentaBancaria
    {
        // CuentaCorriente -> tipo = 2
        public CuentaCorriente(string numero, decimal saldo, string[] titulares) : base(numero, saldo, 2, titulares)
        {

        }
    }
}
