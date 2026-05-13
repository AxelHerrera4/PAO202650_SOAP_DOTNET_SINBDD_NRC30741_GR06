using System.Runtime.Serialization;

namespace ec.edu.monster.vista
{
    [DataContract]
    public class ResultadoConversion
    {
        [DataMember]
        public double Valor { get; set; }

        [DataMember]
        public string UnidadOrigen { get; set; }

        [DataMember]
        public string UnidadDestino { get; set; }

        [DataMember]
        public double Resultado { get; set; }

        [DataMember]
        public string Mensaje { get; set; }
    }
}
