namespace Dsw2025Ej8.Domain;

public class CuentaBancaria
{
    public TipoCuenta _tipo { get; }
    public string _numero { get; }
    public decimal _saldo { get; private set; }
    public Estado _estado { get; private set; }
    public decimal _tasaDeInteres
    {
        get => _tasaDeInteres;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("La tasa de interés no puede ser negativa.");
            } 
            _tasaDeInteres = value;
        }  
    }
    public decimal _limiteDeDescubierto 
    {
        get => _limiteDeDescubierto;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("El limite no puede ser negativa.");
            }
            _limiteDeDescubierto = value;

        }
    }
    public decimal _comision { get; private set; }
    public string[] _titulares { get; }


    public CuentaBancaria(string numero, decimal saldo, TipoCuenta tipo, string[] titulares)
    {
        _numero = numero;
        _saldo = saldo;
        _tipo = tipo;
        _estado = Estado.Activa;
        _titulares = titulares;
    }


    public void Depositar(decimal monto)
    {
        if (monto <= 0)
        {
            throw new MontoNoValido();
        }
        if (_tipo == TipoCuenta.CajaDeAhorro)
            {
                _saldo += monto;
            }
            else if (_tipo == TipoCuenta.CuentaCorriente)
            {
                monto -= monto * _comision;
                _saldo += monto;
            }
        
    }

    public void Retirar(decimal monto)
    {
        if (monto <= 0)
        {
            throw new MontoNoValido();
        }
            if (_tipo == TipoCuenta.CajaDeAhorro)
            {
                _saldo -= monto;
            }
            else if (_tipo == TipoCuenta.CuentaCorriente)
            {
                if (_saldo - monto >= -_limiteDeDescubierto)
                {
                    _saldo -= monto;
                }
                if (_saldo < 0)
                {
                    _estado = Estado.Suspendida;
                }
            }
        
    }

    public void AplicarInteres()
    {
        if (_tipo == TipoCuenta.CajaDeAhorro)
        {
            _saldo += _saldo * _tasaDeInteres;
        }
    }
    public class MontoNoValido : Exception
    {
        public MontoNoValido() : base("El monto ingresado no es válido para la operación solicitada.") { }
    }
}
