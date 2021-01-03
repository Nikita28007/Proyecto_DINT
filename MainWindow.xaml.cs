using Microsoft.Win32;
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

namespace Proyecto_DINT
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<Peliculas> listaPelicula;

        public MainWindow()
        {

            InitializeComponent();
            listaPelicula = Peliculas.listaPeliculas();
            peliDockpanel.DataContext = listaPelicula.FirstOrDefault();
            actualTextBlock.Text = "1";

        }

        private void cargaJSONButton(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog.InitialDirectory = @"c:\Users\%USERNAME%\Documents";
            }
        }

        private void guardaJSONButton(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {

                saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                saveFileDialog.InitialDirectory = @"c:\Users\%USERNAME%\Documents";
            }
        }
        private void examinarButtton(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                openFileDialog.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png|JPEG files (*.jpeg)|*.jpeg|All files (*.*)|*.*";
                openFileDialog.InitialDirectory = @"c:\Users\%USERNAME%\Documents";
                imagenPeli.Text = openFileDialog.FileName;

            }

        }



        private void leftImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int actual = Int32.Parse(actualTextBlock.Text);

            if (actual > 1)
            {
                peliDockpanel.DataContext = listaPelicula[actual - 2];
                actualTextBlock.Text = (actual - 1).ToString();
            }
        }


    }
}
