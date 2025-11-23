using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cajero
{
    public class Banco
    {

        public int ID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Capital { get; set; }

        private static List<Banco> _bancosRegistrados = new List<Banco>();

        private static List<Tarjeta> _tarjetasRegistradas = new List<Tarjeta>();

        private static List<Cajero> _cajerosRegistrados = new List<Cajero>();

        public Banco(int id, string nombre, decimal capital)
        {
            ID = id;
            Nombre = nombre;
            Capital = capital;
        }

        public static Banco CrearBanco(int id, string nombre, decimal capital)
        {
            if (_bancosRegistrados.Any(b => b.ID == id))
            {
                throw new Exception("El banco ya está registrado.");
            }
            var nuevoBanco = new Banco(id, nombre, capital);
            _bancosRegistrados.Add(nuevoBanco);
            return nuevoBanco;
        }

        public static Cajero CrearCajero(Cajero cajero)
        {
            if (_cajerosRegistrados.Any(b => b.Id == cajero.Id))
            {
                throw new Exception("El Cajero ya está registrado.");
            }
            _cajerosRegistrados.Add(cajero);
            return cajero;
        }

        public Tarjeta CrearTarjeta(Tarjeta tarjeta)
        {
            if (_tarjetasRegistradas.Any(b => b.Id == tarjeta.Id))
            {
                throw new Exception("La tarjeta ya está registrada.");
            }

            Capital += tarjeta.Saldo;

            _tarjetasRegistradas.Add(tarjeta);
            return tarjeta;
        }

        public decimal AgregarCapital(decimal monto)
        {
            Capital += monto;
            return Capital;
        }

        public static string AgregarCapitalCajero(Cajero cajero, decimal monto)
        {
            if (!cajero.Estado)
            {
                throw new Exception("El cajero esta inactivo");
            }
            cajero.Saldo += monto;
            return "Monto agreado correctamente.";
        }

        public static string CambiarEstadoCajero(Cajero cajero)
        {
            if (cajero.Estado == false)
            {
                cajero.Estado = true;
                return "Cajero activado correctamente.";
            }
            else
            {
                cajero.Estado = false;
                return "Cajero inactivado correctamente.";

            }
        }

        public static void ListarCajeros(Tarjeta tarjeta)
        {
            var cajerosDelBanco = _cajerosRegistrados.Where(c => c.Banco == tarjeta.Banco).ToList();
            foreach (var cajero in cajerosDelBanco)
            {
                Console.WriteLine($"ID: {cajero.Id}, Banco: {cajero.Banco}, Saldo: {cajero.Saldo}, Estado: {cajero.Estado}");
            }
        }

        public static bool ValidarTarjeta(Tarjeta tarjeta, decimal cvv)
        {
            if (!tarjeta.Estado)
                throw new Exception("Tarjeta inactiva");

            var t = _tarjetasRegistradas.Find(t => t.Id == tarjeta.Id && t.CVV == cvv && t.Banco == tarjeta.Banco);

            if (t == null)
                tarjeta.Intentos += 1;

            if (tarjeta.Intentos == 3)
            {
                tarjeta.Estado = false;
                throw new Exception("Tarjeta bloqueada, demasiados intentos. ");
            }

                return t != null;
        }
        
            
    }
}
