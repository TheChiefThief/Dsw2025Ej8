namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{
    public int _tipo { get; }
    public string _numero { get; }
    public decimal _saldo { get; protected set; }
    public Estado _estado { get; private set; }
    public decimal _tasaDeInteres
    {
        get => _tasaDeInteres;
        init
        {
            if (value < 0)
            {
                throw new ArgumentException("La tasa de interes no puede ser negativa.");
            }
            _tasaDeInteres = value;
        }  
    }
    public decimal _limiteDeDescubierto 
    {
        get => _limiteDeDescubierto;
        init
        {
            if (value < 0)
            {
                throw new ArgumentException("El limite no puede ser negativo.");
            }
            _limiteDeDescubierto = value;

        }
    }
    public decimal _comision { get; private set; }
    public string[] _titulares { get; }

    
    public CuentaBancaria(string numero, decimal saldo, int tipo, string[] titulares)
    {
        _numero = numero;
        _saldo = saldo;
        _tipo = tipo;
        _estado = Estado.Activa;
        _titulares = titulares;
    }


    public void Depositar(decimal monto)
    {
        if (_estado != Estado.Activa)
        {
            throw new Excepciones.CuentaNoActiva();
        }
        if (monto <= 0)
        {
            throw new Excepciones.MontoNoValido();
        }
        if (_tipo == 1) // Caja de Ahorro
        {
                _saldo += monto;
            }
            else if (_tipo == 2) // Cuenta Corriente
        {
                monto -= monto * _comision;
                _saldo += monto;
            }
        
    }

    public void Retirar(decimal monto)
    {
        if (_estado != Estado.Activa)
        {
            throw new Excepciones.CuentaNoActiva();
        }
        if (monto <= 0)
        {
            throw new Excepciones.MontoNoValido();
        }
            if (_tipo == 1) // Caja de Ahorro
        {
                _saldo -= monto;
            }
            else if (_tipo == 2) // Caja corriente
        {
                if (_saldo - monto >= -_limiteDeDescubierto)
                {
                    _saldo -= monto;
                }
                if (_saldo < 0)
                {
                    _estado = Estado.Suspendida;
                    throw new Excepciones.SaldoInsuficiente();
                }
            }
        
    }

    public void AplicarInteres()
    {
        if (_tipo == 1) // Caja de Ahorro
        {
            _saldo += _saldo * _tasaDeInteres;
        }
    }
    
}
