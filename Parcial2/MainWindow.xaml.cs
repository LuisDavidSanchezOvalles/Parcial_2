using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Parcial2.UI.Registros;

namespace Parcial2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Opciones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (OpcionesComboBox.SelectedIndex)
            {
                case 0:
                    RParcial rPacial = new RParcial();
                    rPacial.Show();
                    break;
            }
        }
    }
}
