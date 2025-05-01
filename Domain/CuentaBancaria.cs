namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria // Colocamos abstract para que no se pueda instanciar directamente
{
    public int _tipo { get; }
    public string _numero { get; }
    public decimal _saldo { get; protected set; }
    public Estado _estado { get; private set; }
    public decimal _tasaDeInteres { get; init; }
    public decimal _limiteDeDescubierto { get; init; }
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
                if(_limiteDeDescubierto < 0) // el limite de descubierto no puede ser menor a cero
                {
                    throw new Exception("El límite de descubierto no puede ser menor a cero.");
                }    

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
        if (_tasaDeInteres <= 0) // la tasa de interés no puede ser menor o igual a cero
        {
            throw new Exception("La tasa de interés no puede ser menor o igual a cero.");
        }
        if (_tipo == 1) // Caja de Ahorro
        {
            _saldo += _saldo * _tasaDeInteres;
        }
    }

    // Solamente para testear
    public void CambiarEstado(Estado nuevoEstado)
    {
        _estado = nuevoEstado;
    }

}
