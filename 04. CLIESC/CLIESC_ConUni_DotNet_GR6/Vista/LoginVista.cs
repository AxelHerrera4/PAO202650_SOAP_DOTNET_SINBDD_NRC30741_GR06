using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLIESC_ConUni_DotNet_GR6.ec.edu.monster.vista
{
    public partial class LoginVista : Form
    {
        public LoginVista()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "monster" && txtPass.Text == "monster9")
            {
                ConversorVista formConversor = new ConversorVista();
                this.Hide();
                formConversor.FormClosed += (s, args) => this.Show();
                formConversor.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
