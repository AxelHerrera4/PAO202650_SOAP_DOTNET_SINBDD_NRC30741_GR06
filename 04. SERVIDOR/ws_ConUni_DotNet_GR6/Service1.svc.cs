using System;

namespace ws_ConUni_DotNet_GR6
{
    public class Service1 : IService1
    {
        // ============ TEMPERATURA ============
        public double CelsiusAFahrenheit(double celsius) => (celsius * 9 / 5) + 32;
        public double FahrenheitACelsius(double fahrenheit) => (fahrenheit - 32) * 5 / 9;
        public double CelsiusAKelvin(double celsius) => celsius + 273.15;
        public double KelvinACelsius(double kelvin) => kelvin - 273.15;
        public double FahrenheitAKelvin(double fahrenheit) => (fahrenheit - 32) * 5 / 9 + 273.15;
        public double KelvinAFahrenheit(double kelvin) => (kelvin - 273.15) * 9 / 5 + 32;

        // ============ LONGITUD ============
        public double KmAMetros(double kilometros) => kilometros * 1000;
        public double MetrosACm(double metros) => metros * 100;
        public double PulgadasACm(double pulgadas) => pulgadas * 2.54;
        public double PiesAMetros(double pies) => pies * 0.3048;
        public double MillasAKm(double millas) => millas * 1.60934;

        // ============ MASA ============
        public double KgAGramos(double kilogramos) => kilogramos * 1000;
        public double GramosAMg(double gramos) => gramos * 1000;
        public double LibrasAKg(double libras) => libras * 0.453592;
        public double OnzasAGramos(double onzas) => onzas * 28.3495;
        public double ToneladasAKg(double toneladas) => toneladas * 1000;
    }
}