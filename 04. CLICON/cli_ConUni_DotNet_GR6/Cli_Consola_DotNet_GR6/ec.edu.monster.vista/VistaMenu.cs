using ec.edu.monster.modelo;

namespace ec.edu.monster.vista
{
    public class VistaMenu
    {
        public int MostrarMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("=== MENÚ PRINCIPAL ===");
            Console.WriteLine("1. Conversiones de Temperatura");
            Console.WriteLine("2. Conversiones de Longitud");
            Console.WriteLine("3. Conversiones de Masa");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();
            return int.TryParse(opcion, out int result) ? result : 0;
        }

        public int MostrarMenuTemperatura()
        {
            Console.Clear();
            Console.WriteLine("-- TEMPERATURA --");
            Console.WriteLine("1. Celsius a Fahrenheit");
            Console.WriteLine("2. Fahrenheit a Celsius");
            Console.WriteLine("3. Celsius a Kelvin");
            Console.WriteLine("4. Kelvin a Celsius");
            Console.WriteLine("5. Fahrenheit a Kelvin");
            Console.WriteLine("6. Kelvin a Fahrenheit");
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione: ");

            string subOp = Console.ReadLine();
            return int.TryParse(subOp, out int result) ? result : 0;
        }

        public int MostrarMenuLongitud()
        {
            Console.Clear();
            Console.WriteLine("-- LONGITUD --");
            Console.WriteLine("1. Kilómetros a Metros");
            Console.WriteLine("2. Metros a Centímetros");
            Console.WriteLine("3. Pulgadas a Centímetros");
            Console.WriteLine("4. Pies a Metros");
            Console.WriteLine("5. Millas a Kilómetros");
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione: ");

            string subOp = Console.ReadLine();
            return int.TryParse(subOp, out int result) ? result : 0;
        }

        public int MostrarMenuMasa()
        {
            Console.Clear();
            Console.WriteLine("-- MASA --");
            Console.WriteLine("1. Kilogramos a Gramos");
            Console.WriteLine("2. Gramos a Miligramos");
            Console.WriteLine("3. Libras a Kilogramos");
            Console.WriteLine("4. Onzas a Gramos");
            Console.WriteLine("5. Toneladas a Kilogramos");
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione: ");

            string subOp = Console.ReadLine();
            return int.TryParse(subOp, out int result) ? result : 0;
        }

        public double ObtenerValor(string mensaje = "Ingrese valor: ")
        {
            Console.Write(mensaje);
            if (double.TryParse(Console.ReadLine(), out double val))
            {
                return val;
            }
            return 0;
        }

        public void MostrarResultado(ConversionModelo conversion)
        {
            Console.WriteLine($"\n{conversion.Descripcion}");
            Console.WriteLine($">> Valor ingresado: {conversion.Valor:N2}");
            Console.WriteLine($">> Resultado: {conversion.Resultado:N2}");
            Console.WriteLine("\nPresione Enter para continuar...");
            Console.ReadLine();
        }

        public void MostrarError(string mensaje)
        {
            Console.WriteLine($"\n[!] Error: {mensaje}");
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        public void MostrarOpcionNoValida()
        {
            Console.WriteLine("Opción no válida.");
            System.Threading.Thread.Sleep(1000);
        }
    }
}
