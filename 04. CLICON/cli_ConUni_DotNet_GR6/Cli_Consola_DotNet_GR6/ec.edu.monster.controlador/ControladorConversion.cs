using MiServicio;
using ec.edu.monster.modelo;

namespace ec.edu.monster.controlador
{
    public class ControladorConversion
    {
        private readonly Service1Client _cliente;

        public ControladorConversion(Service1Client cliente)
        {
            _cliente = cliente;
        }

        public async Task<ConversionModelo> ProcesarTemperatura(int opcion, double valor)
        {
            double resultado = 0;
            string descripcion = "";

            try
            {
                resultado = opcion switch
                {
                    1 => await _cliente.CelsiusAFahrenheitAsync(valor),
                    2 => await _cliente.FahrenheitACelsiusAsync(valor),
                    3 => await _cliente.CelsiusAKelvinAsync(valor),
                    4 => await _cliente.KelvinACelsiusAsync(valor),
                    5 => await _cliente.FahrenheitAKelvinAsync(valor),
                    6 => await _cliente.KelvinAFahrenheitAsync(valor),
                    _ => 0
                };

                descripcion = opcion switch
                {
                    1 => "Conversión: Celsius → Fahrenheit",
                    2 => "Conversión: Fahrenheit → Celsius",
                    3 => "Conversión: Celsius → Kelvin",
                    4 => "Conversión: Kelvin → Celsius",
                    5 => "Conversión: Fahrenheit → Kelvin",
                    6 => "Conversión: Kelvin → Fahrenheit",
                    _ => "Conversión no válida"
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en conversión de temperatura: {ex.Message}");
            }

            return new ConversionModelo("Temperatura", valor, resultado, descripcion);
        }

        public async Task<ConversionModelo> ProcesarLongitud(int opcion, double valor)
        {
            double resultado = 0;
            string descripcion = "";

            try
            {
                resultado = opcion switch
                {
                    1 => await _cliente.KmAMetrosAsync(valor),
                    2 => await _cliente.MetrosACmAsync(valor),
                    3 => await _cliente.PulgadasACmAsync(valor),
                    4 => await _cliente.PiesAMetrosAsync(valor),
                    5 => await _cliente.MillasAKmAsync(valor),
                    _ => 0
                };

                descripcion = opcion switch
                {
                    1 => "Conversión: Kilómetros → Metros",
                    2 => "Conversión: Metros → Centímetros",
                    3 => "Conversión: Pulgadas → Centímetros",
                    4 => "Conversión: Pies → Metros",
                    5 => "Conversión: Millas → Kilómetros",
                    _ => "Conversión no válida"
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en conversión de longitud: {ex.Message}");
            }

            return new ConversionModelo("Longitud", valor, resultado, descripcion);
        }

        public async Task<ConversionModelo> ProcesarMasa(int opcion, double valor)
        {
            double resultado = 0;
            string descripcion = "";

            try
            {
                resultado = opcion switch
                {
                    1 => await _cliente.KgAGramosAsync(valor),
                    2 => await _cliente.GramosAMgAsync(valor),
                    3 => await _cliente.LibrasAKgAsync(valor),
                    4 => await _cliente.OnzasAGramosAsync(valor),
                    5 => await _cliente.ToneladasAKgAsync(valor),
                    _ => 0
                };

                descripcion = opcion switch
                {
                    1 => "Conversión: Kilogramos → Gramos",
                    2 => "Conversión: Gramos → Miligramos",
                    3 => "Conversión: Libras → Kilogramos",
                    4 => "Conversión: Onzas → Gramos",
                    5 => "Conversión: Toneladas → Kilogramos",
                    _ => "Conversión no válida"
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en conversión de masa: {ex.Message}");
            }

            return new ConversionModelo("Masa", valor, resultado, descripcion);
        }
    }
}
