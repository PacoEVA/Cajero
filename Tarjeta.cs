using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cajero
{
    public class Tarjeta
    {
        public int Id { get; set; }
        public Banco Banco { get; set; }
        public string Titular { get; set; } = string.Empty;
        public int CVV { get; set; }
        public decimal Saldo { get; set; }
        public bool Estado { get; set; } = true;
        public int Intentos { get; set; } = 0;

        private static List<Tarjeta> _tarjetasRegistradas = [];

        public Tarjeta(int id, string titular, int cvv, decimal saldo, Banco banco, bool estado)
        {
            Id = id;
            Titular = titular;
            CVV = cvv;
            Saldo = saldo;
            Banco = banco;
            Estado = estado;

        }

        public static void VerTarjeta(Tarjeta tarjeta, int cvv)
        {
            if (!tarjeta.Estado)
            {
                throw new Exception("Esta tarjeta no está activa");
            }
            var t = _tarjetasRegistradas.Find(t => t.Id == tarjeta.Id && t.CVV == cvv && t.Banco == tarjeta.Banco);

            if (t != null)
                Console.WriteLine($"Hola {t?.Titular}, el saldo actual de tu tarjeta es {t?.Saldo}, el estado de tu tarjeta es {t?.Estado} ");
            else
                Console.WriteLine("No pudimos acceder a la tarjeta");
        }
    }
}
 