namespace ec.edu.monster.modelo
{
    public class UsuarioModelo
    {
        public string Usuario { get; set; }
        public string Contrasena { get; set; }

        public UsuarioModelo(string usuario, string contrasena)
        {
            Usuario = usuario;
            Contrasena = contrasena;
        }
    }
}
