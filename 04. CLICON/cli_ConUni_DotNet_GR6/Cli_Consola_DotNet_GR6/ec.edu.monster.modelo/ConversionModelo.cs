namespace ec.edu.monster.modelo
{
    public class ConversionModelo
    {
        public string Tipo { get; set; }
        public double Valor { get; set; }
        public double Resultado { get; set; }
        public string Descripcion { get; set; }

        public ConversionModelo(string tipo, double valor, double resultado, string descripcion)
        {
            Tipo = tipo;
            Valor = valor;
            Resultado = resultado;
            Descripcion = descripcion;
        }
    }
}
