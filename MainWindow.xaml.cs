using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            Pelis.ItemsSource = listaPelicula;
            Console.WriteLine(listaPelicula[0].Nombre);
       
        }

        private void cargarImagenes()
        {
            ObservableCollection<Peliculas> oc;
          
        }

        private void cargaJSONButton(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog.InitialDirectory = @"C:\Users\%USERNAME%\Documents";
            }
        }

        private void guardaJSONButton(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {

                saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                saveFileDialog.InitialDirectory = @"C:\Users\%USERNAME%\Documents";
            }
        }
        private void examinarButtton(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                openFileDialog.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png|JPEG files (*.jpeg)|*.jpeg|All files (*.*)|*.*";
                openFileDialog.InitialDirectory = @"C:\Users\%USERNAME%\Documents";
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

        private void rightImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int actual = Int32.Parse(actualTextBlock.Text);

            if (actual > 1)
            {
                peliDockpanel.DataContext = listaPelicula[actual + 2];
                actualTextBlock.Text = (actual - 1).ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string nivel="";
           
            if (TituloPelicula!= null && pista!= null && imagenPeli!= null && (facilRadioButton.IsChecked == true|| normalRadioButton.IsChecked ==true||dificilRadioButton.IsChecked == true)&&GeneroComboBox.SelectedIndex>-1)
            {
                if (facilRadioButton.IsChecked==true)
                {
                    nivel = "Facil";
                }
              else if (normalRadioButton.IsChecked == true)  nivel = "normal"; 
              else if (dificilRadioButton.IsChecked == true)  nivel = "dificil"; 
                Peliculas pelicula = new Peliculas(imagenPeli.Text,TituloPelicula.Text,pista.Text,nivel,GeneroComboBox.Text);
                
                listaPelicula.Add(pelicula);

                MessageBox.Show("pelicula añadida");
            }
            else
            {
                MessageBox.Show("revisa que se ha introducido todos los datos");
            }
            Pelis.Items.Refresh();
        }

        private void Pelis_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
      
            Eliminar.IsEnabled = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Peliculas peli = (Peliculas)Pelis.SelectedItem;
            if (peli!=null)
            { 
                listaPelicula.Remove((Peliculas)Pelis.SelectedItem);
                Pelis.Items.Remove(peli);
               
            }
        
        }
    }
}
