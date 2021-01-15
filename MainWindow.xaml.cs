using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

    public partial class MainWindow : Window
    {
        int puntuacion = 0;
        int peliAdivinada = 4;
        int generoDificil = 3;
        int generoMedio = 2;
        int generoFacil = 1;
        int contador = 0;
        private Peliculas peliculaActiva = new Peliculas();
        private List<Peliculas> p = new List<Peliculas>();
        private List<Peliculas> listaPelicula;

        public MainWindow()
        {

            InitializeComponent();
            listaPelicula = Peliculas.listaPeliculas();
            peliDockpanel.DataContext = listaPelicula.FirstOrDefault();
            Pelis.ItemsSource = listaPelicula;
            if (listaPelicula.Count >= 5)
            {
                PeliculasAleatoria();
            }



        }

        private void fijarImagen(int index)
        {
            string imagen;
            imagen = p[index].Imagen;
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(imagen, UriKind.RelativeOrAbsolute);
            bitmapImage.EndInit();
            JuegoImage.Source = bitmapImage;
            BitmapImage generos = new BitmapImage();
           
            switch (peliculaActiva.Genero)
            {
                case "accion":
                    generos.BeginInit();
                    generos.UriSource = new Uri("../generos/acción.jpg", UriKind.RelativeOrAbsolute);
                    generos.EndInit();
                    generoImage.Source = generos;
                    break;

                case "Comedia":
                    generos.BeginInit();
                    generos.UriSource = new Uri("../generos/comedia.jpg", UriKind.RelativeOrAbsolute);
                    generos.EndInit();
                    generoImage.Source = generos;
                    break;

                case "Drama":
                    generos.BeginInit();
                    generos.UriSource = new Uri("../generos/drama.jpg", UriKind.RelativeOrAbsolute);
                    generos.EndInit();
                    generoImage.Source = generos;
                    break;
                case "Terror":
                    generos.BeginInit();
                    generos.UriSource = new Uri("../generos/terror.jpg", UriKind.RelativeOrAbsolute);
                    generos.EndInit();
                    generoImage.Source = generos;
                    break;
                case "Ficcion":
                    generos.BeginInit();
                    generos.UriSource = new Uri("../generos/ficción.jpg", UriKind.RelativeOrAbsolute);
                    generos.EndInit();
                    generoImage.Source = generos;
                    break;
                case "Ciencia":
                    generos.BeginInit();
                    generos.UriSource = new Uri("../generos/Ciencia.jpg", UriKind.RelativeOrAbsolute);
                    generos.EndInit();
                    generoImage.Source = generos;
                    break;

                default:
                    break;
            }

            switch (peliculaActiva.Nivel)
            {
                case "dificil":
                    mainGrid.Background = Brushes.DarkRed;
                    break;
                case "medio":
                    mainGrid.Background = Brushes.DarkGoldenrod;
                    break;
                case "facil":
                    mainGrid.Background = Brushes.DarkGreen;
                    break;
                default:
                    break;
            }

        }

        
        private void PeliculasAleatoria()
        {
            int peliRandom;


            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                peliRandom = rnd.Next(0, listaPelicula.Count);
                p.Add(listaPelicula[peliRandom]);
            }
            peliculaActiva = p[0];
            fijarImagen(0);
        }


        private void cargaJSONButton(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            if (openFileDialog.ShowDialog() == true)
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog.InitialDirectory = @"C:\Users\%USERNAME%\Documents";

                if (openFileDialog.FileName.Trim() != string.Empty)
                {
                    using (StreamReader r = new StreamReader(openFileDialog.FileName))
                    {
                        string json = r.ReadToEnd();
                        listaPelicula = JsonConvert.DeserializeObject<List<Peliculas>>(json);
                        Console.WriteLine("Hola mundo" + listaPelicula[3].Nombre);
                    }
                }
            }
            Pelis.ItemsSource = listaPelicula;
            Pelis.Items.Refresh();
        }

        private void guardaJSONButton(object sender, RoutedEventArgs e)
        {


            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {

                saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                saveFileDialog.InitialDirectory = @"C:\Users\%USERNAME%\Documents";

                string output = JsonConvert.SerializeObject(listaPelicula);
                try
                {
                    string name = saveFileDialog.FileName;
                    using (StreamWriter sw = new StreamWriter(name))
                        sw.WriteLine(output);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

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


            if (contador >= 1 && p.Count >= 4)
            {
                contador--;
                peliculaActiva = p[contador];
                fijarImagen(contador);

            }
            actualTextBlock.Text = (contador + 1).ToString();
        }

        private void rightImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {


            if (contador < 4 && p.Count >= 4)
            {
                contador++;
                peliculaActiva = p[contador];

                fijarImagen(contador);

            }
            maximoTextBlock.Text = (contador + 1).ToString();
        }

        private void anyadirButton(object sender, RoutedEventArgs e)
        {
            string nivel = "";

            if (TituloPelicula != null && pista != null && imagenPeli != null && (facilRadioButton.IsChecked == true || normalRadioButton.IsChecked == true || dificilRadioButton.IsChecked == true) && GeneroComboBox.SelectedIndex > -1)
            {
                if (facilRadioButton.IsChecked == true)
                {
                    nivel = "Facil";
                }
                else if (normalRadioButton.IsChecked == true) nivel = "normal";
                else if (dificilRadioButton.IsChecked == true) nivel = "dificil";
                Peliculas pelicula = new Peliculas(imagenPeli.Text, TituloPelicula.Text, pista.Text, nivel, GeneroComboBox.Text);

                listaPelicula.Add(pelicula);

                MessageBox.Show("pelicula añadida");
            }
            else
            {
                MessageBox.Show("revisa que se ha introducido todos los datos");
            }
            Pelis.Items.Refresh();
        }

        private void habilitarBoton(object sender, SelectionChangedEventArgs e)
        {

            Eliminar.IsEnabled = true;
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            bool selccionado = true;

            Pelis.SelectedItem = selccionado;
            Peliculas peli = (Peliculas)Pelis.SelectedItem;
            if (peli != null)
            {
                listaPelicula.Remove((Peliculas)Pelis.SelectedItem);


            }
            Pelis.Items.Refresh();
        }

        private void validarButton(object sender, RoutedEventArgs e)
        {
            if (TituloTextBox.Text.Equals(peliculaActiva.Nombre))
            {

                if (verPistaCheckBox.IsChecked == true)
                {
                    peliAdivinada = peliAdivinada / 2;
                    puntuacion += peliAdivinada;
                }
                else
                {
                    puntuacion += peliAdivinada;
                }

                if (peliculaActiva.Nivel.Equals("dificil"))
                {
                    puntuacion += generoDificil;
                }
                else if (peliculaActiva.Nivel.Equals("medio")) { puntuacion += generoMedio; }
                else if (peliculaActiva.Nivel.Equals("facil")) { puntuacion += generoFacil; }
                PuntuacionLabel.Content = puntuacion;


                TituloTextBox.Text = "";
            }
            else
            {
                TituloTextBox.Text = "Titulo incorrecto";
            }

        }

        private void nuevaPartidaButton_click(object sender, RoutedEventArgs e)
        {
            if (listaPelicula.Count >= 5)
            {
                PeliculasAleatoria();

            }
            else
            {
                MessageBox.Show("Debe haber al menos 5 peliculas");
            }

        }

        private void verPistaCheckBox_checked(object sender, RoutedEventArgs e)
        {
            textoPistaTextBlock.Text = peliculaActiva.Pista;
        }
    }
}
