using System.ServiceModel;

namespace ec.edu.monster.modelo
{
    [ServiceContract]
    public interface IService1
    {
        // ============ TEMPERATURA ============
        [OperationContract]
        double CelsiusAFahrenheit(double celsius);

        [OperationContract]
        double FahrenheitACelsius(double fahrenheit);

        [OperationContract]
        double CelsiusAKelvin(double celsius);

        [OperationContract]
        double KelvinACelsius(double kelvin);

        [OperationContract]
        double FahrenheitAKelvin(double fahrenheit);

        [OperationContract]
        double KelvinAFahrenheit(double kelvin);

        // ============ LONGITUD ============
        [OperationContract]
        double KmAMetros(double kilometros);

        [OperationContract]
        double MetrosACm(double metros);

        [OperationContract]
        double PulgadasACm(double pulgadas);

        [OperationContract]
        double PiesAMetros(double pies);

        [OperationContract]
        double MillasAKm(double millas);

        // ============ MASA ============
        [OperationContract]
        double KgAGramos(double kilogramos);

        [OperationContract]
        double GramosAMg(double gramos);

        [OperationContract]
        double LibrasAKg(double libras);

        [OperationContract]
        double OnzasAGramos(double onzas);

        [OperationContract]
        double ToneladasAKg(double toneladas);
    }
}
