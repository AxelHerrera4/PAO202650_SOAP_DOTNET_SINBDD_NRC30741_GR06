using System;
using System.Drawing;
using System.Windows.Forms;
using CLIESC_ConUni_DotNet_GR6.ec.edu.monster.controlador;

namespace CLIESC_ConUni_DotNet_GR6.ec.edu.monster.vista
{
    public partial class ConversorVista : Form
    {
        private ConversorControlador _controlador;

        public ConversorVista()
        {
            InitializeComponent();
            _controlador = new ConversorControlador();
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

            // Obtener operaciones desde el controlador
            var operaciones = _controlador.ObtenerOperacionesPorCategoria();
            if (operaciones.ContainsKey(categoria))
            {
                cmbOperacion.Items.AddRange(operaciones[categoria].ToArray());
            }

            // Actualizar descripción desde el controlador
            lblIngresaValor.Text = _controlador.ObtenerDescripcion(categoria);

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

        private async void btnConvertir_Click(object sender, EventArgs e)
        {
            // Validar el valor usando el controlador
            if (!_controlador.ValidarValor(txtValor.Text))
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblResultado.Text = "Procesando...";
            btnConvertir.Enabled = false;

            try
            {
                double valor = double.Parse(txtValor.Text);
                string categoria = cmbCategoria.SelectedItem.ToString();
                string operacion = cmbOperacion.SelectedItem.ToString();

                // Llamar al controlador para hacer la conversión
                double resultado = await _controlador.ConvertirAsync(categoria, operacion, valor);
                lblResultado.Text = resultado.ToString("G");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al contactar el servicio: {ex.Message}", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblResultado.Text = "Error.";
            }
            finally
            {
                btnConvertir.Enabled = true;
            }
        }
    }
}
            }
            finally
            {
                btnConvertir.Enabled = true;
            }
        }
    }
}
