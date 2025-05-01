using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8.Domain
{
    public class Tests
    {
        public void Ejecutar()
        {
            string[] listatitulares = { "Francisco", "Julian", "Lucciano", "Nachovich" };
            CuentaCorriente cuenta1 = new CuentaCorriente("56897", 523, listatitulares)
            {
                _limiteDeDescubierto = 1000
            };
            CuentaCorriente cuenta2 = new CuentaCorriente("58089", 2015, listatitulares)
            {
                _limiteDeDescubierto = 7000
            };
            CajaDeAhorro cuenta3 = new CajaDeAhorro("58099", 523, listatitulares)
            {
                _tasaDeInteres = 0.05m
            };
            CajaDeAhorro cuenta4 = new CajaDeAhorro("56893", 523, listatitulares)
            {
                _tasaDeInteres = 0.09m
            };


            Console.WriteLine("==== Test 1: Depositar monto no válido ====");
            try
            {
                cuenta1.Depositar(0); // Monto inválido
            }
            catch (Excepciones.MontoNoValido ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }

            Console.WriteLine("==== Test 2: Retirar más del saldo permitido (deja en descubierto) ====");
            try
            {
                cuenta2.Retirar(8000); // Saldo insuficiente, queda suspendida
            }
            catch (Excepciones.SaldoInsuficiente ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }

            Console.WriteLine("==== Test 3: Intentar operar con cuenta suspendida ====");
            try
            {
                cuenta2.Depositar(1000); // No debería dejar porque la cuenta quedó suspendida
            }
            catch (Excepciones.CuentaNoActiva ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }

            Console.WriteLine("\n");


            var resumenCuentas = new[] // Clases anónimas
            {
                new { Nombre = "cuenta 1", Numero = cuenta1._numero, Estado = cuenta1._estado, Saldo = cuenta1._saldo },
                new { Nombre = "cuenta 2", Numero = cuenta2._numero, Estado = cuenta2._estado, Saldo = cuenta2._saldo },
                new { Nombre = "cuenta 3", Numero = cuenta3._numero, Estado = cuenta3._estado, Saldo = cuenta3._saldo },
                new { Nombre = "cuenta 4", Numero = cuenta4._numero, Estado = cuenta4._estado, Saldo = cuenta4._saldo },
            };

            foreach (var cuenta in resumenCuentas)
            {
                Console.WriteLine($"==== Estado final de la {cuenta.Nombre} ====");
                Console.WriteLine($"Cuenta: {cuenta.Numero}, Estado: {cuenta.Estado}, Saldo: {cuenta.Saldo}");
            }

        }
    }
}
