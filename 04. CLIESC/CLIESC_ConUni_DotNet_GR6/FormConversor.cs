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

        private async void btnConvertir_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtValor.Text, out double valor))
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblResultado.Text = "Procesando...";
            btnConvertir.Enabled = false;

            try
            {
                var proxy = new CLIESC_ConUni_DotNet_GR6.MiServicio.Service1Client();
                string operacion = cmbOperacion.SelectedItem.ToString();
                double resultado = 0;

                switch (operacion)
                {
                    // LONGITUD
                    case "Kilometros a Metros": resultado = await proxy.KmAMetrosAsync(valor); break;
                    case "Metros a Centimetros": resultado = await proxy.MetrosACmAsync(valor); break;
                    case "Pulgadas a Centimetros": resultado = await proxy.PulgadasACmAsync(valor); break;
                    case "Pies a Metros": resultado = await proxy.PiesAMetrosAsync(valor); break;
                    case "Millas a Kilometros": resultado = await proxy.MillasAKmAsync(valor); break;

                    // TEMPERATURA
                    case "Celsius a Fahrenheit": resultado = await proxy.CelsiusAFahrenheitAsync(valor); break;
                    case "Fahrenheit a Celsius": resultado = await proxy.FahrenheitACelsiusAsync(valor); break;
                    case "Celsius a Kelvin": resultado = await proxy.CelsiusAKelvinAsync(valor); break;
                    case "Kelvin a Celsius": resultado = await proxy.KelvinACelsiusAsync(valor); break;
                    case "Fahrenheit a Kelvin": resultado = await proxy.FahrenheitAKelvinAsync(valor); break;
                    case "Kelvin a Fahrenheit": resultado = await proxy.KelvinAFahrenheitAsync(valor); break;

                    // MASA
                    case "Kilogramos a Gramos": resultado = await proxy.KgAGramosAsync(valor); break;
                    case "Gramos a Kilogramos": resultado = await proxy.GramosAMgAsync(valor); break; // Asegúrate de que el nombre del método coincida con lo necesario, el WS dice GramosAMg
                    case "Libras a Kilogramos": resultado = await proxy.LibrasAKgAsync(valor); break;
                    case "Onzas a Gramos": resultado = await proxy.OnzasAGramosAsync(valor); break;
                }

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
