using System;
using System.Threading.Tasks;
using MiServicio;
using ec.edu.monster.vista;
using ec.edu.monster.controlador;

// === INICIALIZACIÓN DEL SISTEMA ===
var vistaAutenticacion = new VistaAutenticacion();
var vistaMenu = new VistaMenu();
var controladorAutenticacion = new ControladorAutenticacion();

// === AUTENTICACIÓN ===
bool autenticado = false;
while (!autenticado)
{
    var usuario = vistaAutenticacion.MostrarPantallaLogin();

    if (controladorAutenticacion.ValidarCredenciales(usuario))
    {
        vistaAutenticacion.MostrarAccesoConcedido();
        autenticado = true;
    }
    else
    {
        vistaAutenticacion.MostrarCredencialesIncorrectas();
    }
}

// === INICIALIZAR CLIENTE DEL SERVICIO ===
using var cliente = new Service1Client();
var controladorConversion = new ControladorConversion(cliente);

try
{
    bool continuar = true;
    while (continuar)
    {
        int opcionPrincipal = vistaMenu.MostrarMenuPrincipal();

        switch (opcionPrincipal)
        {
            case 1:
                await ProcesarTemperatura(controladorConversion, vistaMenu);
                break;
            case 2:
                await ProcesarLongitud(controladorConversion, vistaMenu);
                break;
            case 3:
                await ProcesarMasa(controladorConversion, vistaMenu);
                break;
            case 4:
                continuar = false;
                break;
            default:
                vistaMenu.MostrarOpcionNoValida();
                break;
        }
    }
}
catch (Exception ex)
{
    vistaAutenticacion.MostrarErrorComunicacion(ex.Message);
}

vistaAutenticacion.MostrarMensajeDespedida();

// === MÉTODOS DE PROCESAMIENTO ===

async Task ProcesarTemperatura(ControladorConversion controlador, VistaMenu vista)
{
    int opcion = vista.MostrarMenuTemperatura();

    if (opcion == 0) return;

    double valor = vista.ObtenerValor();

    try
    {
        var resultado = await controlador.ProcesarTemperatura(opcion, valor);
        vista.MostrarResultado(resultado);
    }
    catch (Exception ex)
    {
        vista.MostrarError(ex.Message);
    }
}

async Task ProcesarLongitud(ControladorConversion controlador, VistaMenu vista)
{
    int opcion = vista.MostrarMenuLongitud();

    if (opcion == 0) return;

    double valor = vista.ObtenerValor();

    try
    {
        var resultado = await controlador.ProcesarLongitud(opcion, valor);
        vista.MostrarResultado(resultado);
    }
    catch (Exception ex)
    {
        vista.MostrarError(ex.Message);
    }
}

async Task ProcesarMasa(ControladorConversion controlador, VistaMenu vista)
{
    int opcion = vista.MostrarMenuMasa();

    if (opcion == 0) return;

    double valor = vista.ObtenerValor();

    try
    {
        var resultado = await controlador.ProcesarMasa(opcion, valor);
        vista.MostrarResultado(resultado);
    }
    catch (Exception ex)
    {
        vista.MostrarError(ex.Message);
    }
}