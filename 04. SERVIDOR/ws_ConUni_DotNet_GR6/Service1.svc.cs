using System;
using ec.edu.monster.modelo;
using ec.edu.monster.controlador;

namespace ws_ConUni_DotNet_GR6
{
    public class Service1 : IService1
    {
        private readonly ec.edu.monster.controlador.Service1 _controller = new ec.edu.monster.controlador.Service1();

        // ============ TEMPERATURA ============
        public double CelsiusAFahrenheit(double celsius) => _controller.CelsiusAFahrenheit(celsius);
        public double FahrenheitACelsius(double fahrenheit) => _controller.FahrenheitACelsius(fahrenheit);
        public double CelsiusAKelvin(double celsius) => _controller.CelsiusAKelvin(celsius);
        public double KelvinACelsius(double kelvin) => _controller.KelvinACelsius(kelvin);
        public double FahrenheitAKelvin(double fahrenheit) => _controller.FahrenheitAKelvin(fahrenheit);
        public double KelvinAFahrenheit(double kelvin) => _controller.KelvinAFahrenheit(kelvin);

        // ============ LONGITUD ============
        public double KmAMetros(double kilometros) => _controller.KmAMetros(kilometros);
        public double MetrosACm(double metros) => _controller.MetrosACm(metros);
        public double PulgadasACm(double pulgadas) => _controller.PulgadasACm(pulgadas);
        public double PiesAMetros(double pies) => _controller.PiesAMetros(pies);
        public double MillasAKm(double millas) => _controller.MillasAKm(millas);

        // ============ MASA ============
        public double KgAGramos(double kilogramos) => _controller.KgAGramos(kilogramos);
        public double GramosAMg(double gramos) => _controller.GramosAMg(gramos);
        public double LibrasAKg(double libras) => _controller.LibrasAKg(libras);
        public double OnzasAGramos(double onzas) => _controller.OnzasAGramos(onzas);
        public double ToneladasAKg(double toneladas) => _controller.ToneladasAKg(toneladas);
    }
}