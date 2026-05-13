using System;
using System.Collections.Generic;
using System.Linq;
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
            var operaciones = new Dictionary<string, List<string>>
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

            return operaciones;
        }

        public string ObtenerDescripcion(string categoria)
        {
            var descripciones = new Dictionary<string, string>
            {
                { "LONGITUD", "Ingresa unidades de longitud" },
                { "TEMPERATURA", "Ingresa grados Celsius" },
                { "MASA", "Ingresa unidades de masa" }
            };

            return descripciones.ContainsKey(categoria) ? descripciones[categoria] : "Ingresa el valor";
        }

        public async Task<double> ConvertirAsync(string categoria, string operacion, double valor)
        {
            try
            {
                double resultado = 0;

                switch (operacion)
                {
                    // LONGITUD
                    case "Kilometros a Metros":
                        resultado = await _servicioWS.KmAMetrosAsync(valor);
                        break;
                    case "Metros a Centimetros":
                        resultado = await _servicioWS.MetrosACmAsync(valor);
                        break;
                    case "Pulgadas a Centimetros":
                        resultado = await _servicioWS.PulgadasACmAsync(valor);
                        break;
                    case "Pies a Metros":
                        resultado = await _servicioWS.PiesAMetrosAsync(valor);
                        break;
                    case "Millas a Kilometros":
                        resultado = await _servicioWS.MillasAKmAsync(valor);
                        break;

                    // TEMPERATURA
                    case "Celsius a Fahrenheit":
                        resultado = await _servicioWS.CelsiusAFahrenheitAsync(valor);
                        break;
                    case "Fahrenheit a Celsius":
                        resultado = await _servicioWS.FahrenheitACelsiusAsync(valor);
                        break;
                    case "Celsius a Kelvin":
                        resultado = await _servicioWS.CelsiusAKelvinAsync(valor);
                        break;
                    case "Kelvin a Celsius":
                        resultado = await _servicioWS.KelvinACelsiusAsync(valor);
                        break;
                    case "Fahrenheit a Kelvin":
                        resultado = await _servicioWS.FahrenheitAKelvinAsync(valor);
                        break;
                    case "Kelvin a Fahrenheit":
                        resultado = await _servicioWS.KelvinAFahrenheitAsync(valor);
                        break;

                    // MASA
                    case "Kilogramos a Gramos":
                        resultado = await _servicioWS.KgAGramosAsync(valor);
                        break;
                    case "Gramos a Kilogramos":
                        resultado = await _servicioWS.GramosAMgAsync(valor);
                        break;
                    case "Libras a Kilogramos":
                        resultado = await _servicioWS.LibrasAKgAsync(valor);
                        break;
                    case "Onzas a Gramos":
                        resultado = await _servicioWS.OnzasAGramosAsync(valor);
                        break;
                }

                return resultado;
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
    public class ConversorControlador
    {
        private Service1Client _servicioWS;

        public ConversorControlador()
        {
            _servicioWS = new Service1Client();
        }

        public Dictionary<string, List<string>> ObtenerOperacionesPorCategoria()
        {
            var operaciones = new Dictionary<string, List<string>>
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

            return operaciones;
        }

        public string ObtenerDescripcion(string categoria)
        {
            var descripciones = new Dictionary<string, string>
            {
                { "LONGITUD", "Ingresa unidades de longitud" },
                { "TEMPERATURA", "Ingresa grados Celsius" },
                { "MASA", "Ingresa unidades de masa" }
            };

            return descripciones.ContainsKey(categoria) ? descripciones[categoria] : "Ingresa el valor";
        }

        public async Task<double> ConvertirAsync(string categoria, string operacion, double valor)
        {
            try
            {
                double resultado = 0;

                switch (operacion)
                {
                    // LONGITUD
                    case "Kilometros a Metros":
                        resultado = await _servicioWS.KmAMetrosAsync(valor);
                        break;
                    case "Metros a Centimetros":
                        resultado = await _servicioWS.MetrosACmAsync(valor);
                        break;
                    case "Pulgadas a Centimetros":
                        resultado = await _servicioWS.PulgadasACmAsync(valor);
                        break;
                    case "Pies a Metros":
                        resultado = await _servicioWS.PiesAMetrosAsync(valor);
                        break;
                    case "Millas a Kilometros":
                        resultado = await _servicioWS.MillasAKmAsync(valor);
                        break;

                    // TEMPERATURA
                    case "Celsius a Fahrenheit":
                        resultado = await _servicioWS.CelsiusAFahrenheitAsync(valor);
                        break;
                    case "Fahrenheit a Celsius":
                        resultado = await _servicioWS.FahrenheitACelsiusAsync(valor);
                        break;
                    case "Celsius a Kelvin":
                        resultado = await _servicioWS.CelsiusAKelvinAsync(valor);
                        break;
                    case "Kelvin a Celsius":
                        resultado = await _servicioWS.KelvinACelsiusAsync(valor);
                        break;
                    case "Fahrenheit a Kelvin":
                        resultado = await _servicioWS.FahrenheitAKelvinAsync(valor);
                        break;
                    case "Kelvin a Fahrenheit":
                        resultado = await _servicioWS.KelvinAFahrenheitAsync(valor);
                        break;

                    // MASA
                    case "Kilogramos a Gramos":
                        resultado = await _servicioWS.KgAGramosAsync(valor);
                        break;
                    case "Gramos a Kilogramos":
                        resultado = await _servicioWS.GramosAMgAsync(valor);
                        break;
                    case "Libras a Kilogramos":
                        resultado = await _servicioWS.LibrasAKgAsync(valor);
                        break;
                    case "Onzas a Gramos":
                        resultado = await _servicioWS.OnzasAGramosAsync(valor);
                        break;
                }

                return resultado;
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
