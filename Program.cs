using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] listatitulares = { "Francisco", "Julian", "Lucciano" };
            CuentaCorriente _cuenta1 = new CuentaCorriente("0022", 523, TipoCuenta.CuentaCorriente, listatitulares)
            {
                _estado = Estado.Inactiva
                

            };
            _cuenta1.Depositar(2354);

        }
    }
}
