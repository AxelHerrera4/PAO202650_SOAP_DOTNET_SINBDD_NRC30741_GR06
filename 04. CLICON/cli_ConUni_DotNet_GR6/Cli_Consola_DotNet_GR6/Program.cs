using System;
using System.Threading.Tasks;
using MiServicio; // Asegúrate de que este sea el nombre que pusiste al agregar la Service Reference

// 1. Configuración inicial y Login con Reintentos
while (true)
{
    Console.Clear();
    Console.WriteLine("====================================");
    Console.WriteLine("   CLIENTE C# - CONVERSOR ESPE      ");
    Console.WriteLine("====================================");

    Console.Write("Usuario: ");
    string user = Console.ReadLine();
    Console.Write("Contraseña: ");
    string pass = Console.ReadLine();

    if (user == "monster" && pass == "monster9")
    {
        Console.WriteLine("\n[+] Acceso concedido.\n");
        System.Threading.Thread.Sleep(1000);
        break;
    }
    else
    {
        Console.WriteLine("\n[!] Credenciales incorrectas. Intente de nuevo.");
        Console.WriteLine("Presione cualquier tecla para reintentar...");
        Console.ReadKey();
    }
}

// 2. Instanciar el cliente del servicio
using var client = new Service1Client();

try
{
    bool continuar = true;
    while (continuar)
    {
        Console.Clear();
        Console.WriteLine("=== MENÚ PRINCIPAL ===");
        Console.WriteLine("1. Conversiones de Temperatura");
        Console.WriteLine("2. Conversiones de Longitud");
        Console.WriteLine("3. Conversiones de Masa");
        Console.WriteLine("4. Salir");
        Console.Write("Seleccione una opción: ");

        string opcion = Console.ReadLine();

        switch (opcion)
        {
            case "1":
                await MenuTemperatura(client);
                break;
            case "2":
                await MenuLongitud(client);
                break;
            case "3":
                await MenuMasa(client);
                break;
            case "4":
                continuar = false;
                break;
            default:
                Console.WriteLine("Opción no válida.");
                System.Threading.Thread.Sleep(1000);
                break;
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"\n[!] Error de comunicación: {ex.Message}");
    Console.ReadKey();
}

Console.WriteLine("\nGracias por usar ConUni. Presione cualquier tecla para cerrar.");
Console.ReadKey();

// --- MÉTODOS DE MENÚ CON NOMBRES COMPLETOS ---

async Task MenuTemperatura(Service1Client client)
{
    Console.WriteLine("\n-- TEMPERATURA --");
    Console.WriteLine("1. Celsius a Fahrenheit");
    Console.WriteLine("2. Fahrenheit a Celsius");
    Console.WriteLine("3. Celsius a Kelvin");
    Console.WriteLine("4. Kelvin a Celsius");
    Console.WriteLine("5. Fahrenheit a Kelvin");
    Console.WriteLine("6. Kelvin a Fahrenheit");
    Console.Write("Seleccione: ");
    string subOp = Console.ReadLine();

    Console.Write("Ingrese valor: ");
    if (double.TryParse(Console.ReadLine(), out double val))
    {
        double res = subOp switch
        {
            "1" => await client.CelsiusAFahrenheitAsync(val),
            "2" => await client.FahrenheitACelsiusAsync(val),
            "3" => await client.CelsiusAKelvinAsync(val),
            "4" => await client.KelvinACelsiusAsync(val),
            "5" => await client.FahrenheitAKelvinAsync(val),
            "6" => await client.KelvinAFahrenheitAsync(val),
            _ => 0
        };
        Console.WriteLine($">> Resultado: {res:N2}");
        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }
}

async Task MenuLongitud(Service1Client client)
{
    Console.WriteLine("\n-- LONGITUD --");
    Console.WriteLine("1. Kilómetros a Metros");
    Console.WriteLine("2. Metros a Centímetros");
    Console.WriteLine("3. Pulgadas a Centímetros");
    Console.WriteLine("4. Pies a Metros");
    Console.WriteLine("5. Millas a Kilómetros");
    Console.Write("Seleccione: ");
    string subOp = Console.ReadLine();

    Console.Write("Ingrese valor: ");
    if (double.TryParse(Console.ReadLine(), out double val))
    {
        double res = subOp switch
        {
            "1" => await client.KmAMetrosAsync(val),
            "2" => await client.MetrosACmAsync(val),
            "3" => await client.PulgadasACmAsync(val),
            "4" => await client.PiesAMetrosAsync(val),
            "5" => await client.MillasAKmAsync(val),
            _ => 0
        };
        Console.WriteLine($">> Resultado: {res:N2}");
        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }
}

async Task MenuMasa(Service1Client client)
{
    Console.WriteLine("\n-- MASA --");
    Console.WriteLine("1. Kilogramos a Gramos");
    Console.WriteLine("2. Gramos a Miligramos");
    Console.WriteLine("3. Libras a Kilogramos");
    Console.WriteLine("4. Onzas a Gramos");
    Console.WriteLine("5. Toneladas a Kilogramos");
    Console.Write("Seleccione: ");
    string subOp = Console.ReadLine();

    Console.Write("Ingrese valor: ");
    if (double.TryParse(Console.ReadLine(), out double val))
    {
        double res = subOp switch
        {
            "1" => await client.KgAGramosAsync(val),
            "2" => await client.GramosAMgAsync(val),
            "3" => await client.LibrasAKgAsync(val),
            "4" => await client.OnzasAGramosAsync(val),
            "5" => await client.ToneladasAKgAsync(val),
            _ => 0
        };
        Console.WriteLine($">> Resultado: {res:N2}");
        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }
}