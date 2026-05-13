using ec.edu.monster.modelo;

namespace ec.edu.monster.vista
{
    public class VistaAutenticacion
    {
        public UsuarioModelo MostrarPantallaLogin()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("   CLIENTE C# - CONVERSOR ESPE      ");
            Console.WriteLine("====================================\n");

            Console.Write("Usuario: ");
            string usuario = Console.ReadLine();

            Console.Write("Contraseña: ");
            string contrasena = Console.ReadLine();

            return new UsuarioModelo(usuario, contrasena);
        }

        public void MostrarAccesoConcedido()
        {
            Console.WriteLine("\n[+] Acceso concedido.\n");
            System.Threading.Thread.Sleep(1000);
        }

        public void MostrarCredencialesIncorrectas()
        {
            Console.WriteLine("\n[!] Credenciales incorrectas. Intente de nuevo.");
            Console.WriteLine("Presione cualquier tecla para reintentar...");
            Console.ReadKey();
        }

        public void MostrarErrorComunicacion(string mensaje)
        {
            Console.WriteLine($"\n[!] Error de comunicación: {mensaje}");
            Console.ReadKey();
        }

        public void MostrarMensajeDespedida()
        {
            Console.WriteLine("\nGracias por usar ConUni. Presione cualquier tecla para cerrar.");
            Console.ReadKey();
        }
    }
}
