using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] listatitulares = { "Francisco", "Julian", "Lucciano" , "Nachovich"};
            CuentaCorriente cuenta1 = new CuentaCorriente("56897", 523, listatitulares);
            CuentaCorriente cuenta2 = new CuentaCorriente("58089", 523, listatitulares);
            CajaDeAhorro cuenta3 = new CajaDeAhorro("58099", 523, listatitulares);
            CajaDeAhorro cuenta4 = new CajaDeAhorro("56893", 523, listatitulares);
            cuenta1.Depositar(2354);
            cuenta1.Retirar(1000);
            Console.WriteLine($"Numero de cuenta: {cuenta1._numero}, Tipo cuenta: {cuenta1._tipo}, Saldo: {cuenta1._saldo}");
            //cuenta2.Depositar(2354);
            //cuenta3.Depositar(2354);
            //cuenta4.Depositar(2354);
        }
    }
}
