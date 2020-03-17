using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Parcial2.Entidades;
using Parcial2.BLL;

namespace Parcial2.UI.Registros
{
    /// <summary>
    /// Interaction logic for RParcial.xaml
    /// </summary>
    public partial class RParcial : Window
    {
        Contenedor contenedor = new Contenedor();
        public RParcial()
        {
            InitializeComponent();
            this.DataContext = contenedor;
            LlamadaIdTextBox.Text = "0";
        }

        private void Recargar()
        {
            this.DataContext = null;
            this.DataContext = contenedor;
        }

        private void Limpiar()
        {
            LlamadaIdTextBox.Text = "0";
            DescripcionTextBox.Text = string.Empty;
            ProblemaTextBox.Text = string.Empty;
            SolucionTextBox.Text = string.Empty;
            contenedor.llamada = new Llamada();
            contenedor.llamada.LlamadasDetalle = new List<LlamadaDetalle>();
            contenedor.llamadaDetalle = new LlamadaDetalle();
            Recargar();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(LlamadaIdTextBox.Text))
            {
                paso = false;
                MessageBox.Show("EL Campo Id No debe Estar Vacío");
                LlamadaIdTextBox.Focus();
            }
            else
            {
                try
                {
                    int i = Convert.ToInt32(LlamadaIdTextBox.Text);
                }
                catch (FormatException)
                {
                    paso = false;
                    MessageBox.Show("Campo Id Invalido");
                    LlamadaIdTextBox.Focus();
                }
            }

            if (string.IsNullOrWhiteSpace(DescripcionTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El CampoId No debe estar Vacío");
                DescripcionTextBox.Focus();
            }
            else
            { 
                foreach (char caracter in DescripcionTextBox.Text)
                {
                    if (!char.IsLetter(caracter) && !char.IsWhiteSpace(caracter) && !char.IsDigit(caracter))
                    {
                        paso = false;
                        MessageBox.Show("No debe de Contener Caracteres Expeciales");
                        DescripcionTextBox.Focus();
                    }
                }
            }

            if(contenedor.llamada.LlamadasDetalle.Count == 0)
            {
                paso = false;
                MessageBox.Show("Debe De Agregar Al menos un detalle");
            }

            return paso;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Llamada LlamadaAnterior = LlamadasBLL.Buscar(contenedor.llamada.LlamadaId);
            return LlamadaAnterior != null;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!Validar())
                return;

            if (LlamadaIdTextBox.Text == "0")
            {
                paso = LlamadasBLL.Guardar(contenedor.llamada);   
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se Puede Modificar una Llamada Que no Existe");
                    return;
                }
                else
                    paso = LlamadasBLL.Modificar(contenedor.llamada);
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado");
            }
            else
                MessageBox.Show("No se Pudo Guardar porque debe de haber agregado una llamada");
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (LlamadasBLL.Eliminar(contenedor.llamada.LlamadaId))
            {
                Limpiar();
                MessageBox.Show("Eliminado");
            }
            else
                MessageBox.Show("No se Puede Eliminar Una Orden Que no Existe");
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Llamada LlamadaAnterior = LlamadasBLL.Buscar(contenedor.llamada.LlamadaId);

            if (LlamadaAnterior != null)
            {
                contenedor.llamada = LlamadaAnterior;
                Recargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("Orden No Encontrada");
            }
        }

        private bool ValidarAgregarButton()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(ProblemaTextBox.Text))
                paso = false;

            if (string.IsNullOrWhiteSpace(SolucionTextBox.Text))
                paso = false;

            if (paso == false)
                MessageBox.Show("Debes de Agregar un Problema y su Solucion al detalle");

            return paso;
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarAgregarButton())
                return;

            contenedor.llamada.LlamadasDetalle.Add(new LlamadaDetalle(contenedor.llamada.LlamadaId, ProblemaTextBox.Text, SolucionTextBox.Text));

            Recargar();

            ProblemaTextBox.Clear();
            SolucionTextBox.Clear();
            ProblemaTextBox.Focus();
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if (LlamadasDataGrid.Items.Count > 1 && LlamadasDataGrid.SelectedIndex < LlamadasDataGrid.Items.Count - 1)
            {
                contenedor.llamada.LlamadasDetalle.RemoveAt(LlamadasDataGrid.SelectedIndex);
                Recargar();
            }
        }
    }
}
