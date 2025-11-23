using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cajero
{
    public class Cajero
    {
        public int Id { get; set; }
        public Banco Banco { get; set; }
        public decimal Saldo { get; set; }
        public bool Estado { get; set; } = true;

        public int Intentos { get; set; } = 0;

        public Cajero(int id, Banco banco, decimal saldo, bool estado)
        {
            Id = id;
            Banco = banco;
            Saldo = saldo;
            Estado = estado;

        }

        public void Retirar(Tarjeta tarjeta, decimal cantidad, int cvv)
        {
            if (Banco.ValidarTarjeta(tarjeta, cvv) == false || Banco != tarjeta.Banco)
                Console.WriteLine("Error a retirar dinero");

            if (tarjeta.Saldo < cantidad)
                throw new Exception("No tienes fondos suficientes");

            if (!Estado || Saldo < cantidad)
                throw new Exception("El cajero no esta disponible o no tiene saldo");

            tarjeta.Saldo -= cantidad;
            Banco.Capital -= cantidad;
            Saldo -= cantidad;
            Console.WriteLine(Saldo);
        }

        public void Depositar(Tarjeta tarjeta, decimal cantidad, int cvv)
        {
            if (Banco.ValidarTarjeta(tarjeta, cvv) == false || Banco != tarjeta.Banco)
                throw new Exception("Error a retirar dinero");

            if (tarjeta.Saldo < cantidad)
                throw new Exception("No tienes fondos suficientes");

            if (!Estado || Saldo < cantidad)
                throw new Exception("El cajero no esta disponible o no tiene saldo");

            tarjeta.Saldo += cantidad;
            Banco.Capital += cantidad;
            Saldo += cantidad;
            Console.WriteLine(Saldo);
        }


    }
}
