using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    class Excepciones
    {
        public class MontoNoValido : Exception
        {
            public MontoNoValido() : base("El monto ingresado no es válido para la operación solicitada.") { }
        }
        public class CuentaNoActiva : Exception
        {
            public CuentaNoActiva() : base("La cuenta no está activa.") { }
        }
        public class SaldoInsuficiente : Exception
        {
            public SaldoInsuficiente() : base("El saldo es insuficiente.") { }
        }

    }
}
