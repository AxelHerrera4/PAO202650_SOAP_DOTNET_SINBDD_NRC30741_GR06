using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CLIESC_ConUni_DotNet_GR6.ec.edu.monster.modelo;
using CLIESC_ConUni_DotNet_GR6.MiServicio;

namespace CLIESC_ConUni_DotNet_GR6.ec.edu.monster.controlador
{
    public class ConversorControlador
    {
        private Service1Client _servicioWS;

        public ConversorControlador()
        {
            _servicioWS = new Service1Client();
        }

        public Dictionary<string, List<string>> ObtenerOperacionesPorCategoria()
        {
            return new Dictionary<string, List<string>>
            {
                {
                    "LONGITUD", new List<string>
                    {
                        "Kilometros a Metros",
                        "Metros a Centimetros",
                        "Pulgadas a Centimetros",
                        "Pies a Metros",
                        "Millas a Kilometros"
                    }
                },
                {
                    "TEMPERATURA", new List<string>
                    {
                        "Celsius a Fahrenheit",
                        "Fahrenheit a Celsius",
                        "Celsius a Kelvin",
                        "Kelvin a Celsius",
                        "Fahrenheit a Kelvin",
                        "Kelvin a Fahrenheit"
                    }
                },
                {
                    "MASA", new List<string>
                    {
                        "Kilogramos a Gramos",
                        "Gramos a Kilogramos",
                        "Libras a Kilogramos",
                        "Onzas a Gramos"
                    }
                }
            };
        }

        public string ObtenerDescripcion(string categoria)
        {
            var descripciones = new Dictionary<string, string>
            {
                { "LONGITUD",    "Ingresa unidades de longitud" },
                { "TEMPERATURA", "Ingresa grados para convertir" },
                { "MASA",        "Ingresa unidades de masa" }
            };

            return descripciones.ContainsKey(categoria) ? descripciones[categoria] : "Ingresa el valor";
        }

        public async Task<double> ConvertirAsync(string categoria, string operacion, double valor)
        {
            try
            {
                switch (operacion)
                {
                    // LONGITUD
                    case "Kilometros a Metros":      return await _servicioWS.KmAMetrosAsync(valor);
                    case "Metros a Centimetros":     return await _servicioWS.MetrosACmAsync(valor);
                    case "Pulgadas a Centimetros":   return await _servicioWS.PulgadasACmAsync(valor);
                    case "Pies a Metros":            return await _servicioWS.PiesAMetrosAsync(valor);
                    case "Millas a Kilometros":      return await _servicioWS.MillasAKmAsync(valor);

                    // TEMPERATURA
                    case "Celsius a Fahrenheit":     return await _servicioWS.CelsiusAFahrenheitAsync(valor);
                    case "Fahrenheit a Celsius":     return await _servicioWS.FahrenheitACelsiusAsync(valor);
                    case "Celsius a Kelvin":         return await _servicioWS.CelsiusAKelvinAsync(valor);
                    case "Kelvin a Celsius":         return await _servicioWS.KelvinACelsiusAsync(valor);
                    case "Fahrenheit a Kelvin":      return await _servicioWS.FahrenheitAKelvinAsync(valor);
                    case "Kelvin a Fahrenheit":      return await _servicioWS.KelvinAFahrenheitAsync(valor);

                    // MASA
                    case "Kilogramos a Gramos":      return await _servicioWS.KgAGramosAsync(valor);
                    case "Gramos a Kilogramos":      return await _servicioWS.GramosAMgAsync(valor);
                    case "Libras a Kilogramos":      return await _servicioWS.LibrasAKgAsync(valor);
                    case "Onzas a Gramos":           return await _servicioWS.OnzasAGramosAsync(valor);

                    default:
                        throw new Exception($"Operación no reconocida: {operacion}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en la conversión: {ex.Message}", ex);
            }
        }

        public bool ValidarValor(string valor)
        {
            return double.TryParse(valor, out _);
        }
    }
}
