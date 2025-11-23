namespace Cajero
{
    class Program
    {
        static void Main(string[] args)
        {
            var Popular = Banco.CrearBanco(1, "Popular", 500000m);
            var CajeroPopular = Banco.CrearCajero(new Cajero(1, Popular, 50000m, true));
            var TarjetaPOP = Popular.CrearTarjeta(new Tarjeta(1, "Samuel", 1234, 1000000m, Popular, true));

            CajeroPopular.Retirar(TarjetaPOP, 100m, 123);
            CajeroPopular.Retirar(TarjetaPOP, 100m, 123);
            CajeroPopular.Retirar(TarjetaPOP, 100m, 123);
            CajeroPopular.Retirar(TarjetaPOP, 100m, 123);
            Console.WriteLine(Popular.Capital);
        }
    }
    }