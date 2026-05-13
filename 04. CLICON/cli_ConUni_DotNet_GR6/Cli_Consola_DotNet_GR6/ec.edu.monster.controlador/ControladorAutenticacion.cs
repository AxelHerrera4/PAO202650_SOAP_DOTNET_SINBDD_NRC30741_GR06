using ec.edu.monster.modelo;

namespace ec.edu.monster.controlador
{
    public class ControladorAutenticacion
    {
        private const string USUARIO_VALIDO = "monster";
        private const string CONTRASENA_VALIDA = "monster9";

        public bool ValidarCredenciales(UsuarioModelo usuario)
        {
            return usuario.Usuario == USUARIO_VALIDO && usuario.Contrasena == CONTRASENA_VALIDA;
        }
    }
}
