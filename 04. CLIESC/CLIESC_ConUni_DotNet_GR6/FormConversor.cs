using System;
using System.Drawing;
using System.Windows.Forms;

namespace CLIESC_ConUni_DotNet_GR6
{
    public partial class FormConversor : Form
    {
        public FormConversor()
        {
            InitializeComponent();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            // Inicializar opciones de Categoría
            cmbCategoria.Items.AddRange(new string[] { "LONGITUD", "TEMPERATURA", "MASA" });
            cmbCategoria.SelectedIndex = 1; // Seleccionar TEMPERATURA por defecto
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbOperacion.Items.Clear();
            string categoria = cmbCategoria.SelectedItem.ToString();

            // Actualizar el título dinámico
            lblTituloPrincipal.Text = $"CONVERSOR MONSTER | {categoria}";

            if (categoria == "LONGITUD")
            {
                cmbOperacion.Items.AddRange(new string[]
                {
                    "Kilometros a Metros",
                    "Metros a Centimetros",
                    "Pulgadas a Centimetros",
                    "Pies a Metros",
                    "Millas a Kilometros"
                });
                lblIngresaValor.Text = "Ingresa unidades de longitud";
            }
            else if (categoria == "TEMPERATURA")
            {
                cmbOperacion.Items.AddRange(new string[]
                {
                    "Celsius a Fahrenheit",
                    "Fahrenheit a Celsius",
                    "Celsius a Kelvin",
                    "Kelvin a Celsius",
                    "Fahrenheit a Kelvin",
                    "Kelvin a Fahrenheit"
                });
                lblIngresaValor.Text = "Ingresa grados";
            }
            else if (categoria == "MASA")
            {
                cmbOperacion.Items.AddRange(new string[]
                {
                    "Kilogramos a Gramos",
                    "Gramos a Kilogramos",
                    "Libras a Kilogramos",
                    "Onzas a Gramos"
                });
                lblIngresaValor.Text = "Ingresa unidades de masa";
            }

            if (cmbOperacion.Items.Count > 0)
            {
                cmbOperacion.SelectedIndex = 0;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtValor.Clear();
            lblResultado.Text = "Esperando conversion...";
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertir_Click(object sender, EventArgs e)
        {
            // Aquí se implementará la llamada real al servicio SOAP para las conversiones.
            // Por ahora, se simula.
            if (!double.TryParse(txtValor.Text, out double valor))
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string operacion = cmbOperacion.SelectedItem.ToString();
            lblResultado.Text = $"Simulación: {operacion} para el valor {valor}";
        }
    }
}
