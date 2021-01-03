using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_DINT
{
    class Peliculas : INotifyPropertyChanged
    {
        private string _imagen;
        public string Imagen
        {
            get => _imagen;
            set
            {
                if (_imagen != value)
                {
                    _imagen = value;
                    NotifyPropertyChanged("Imagen");
                }
            }
        }

        private string _nombre;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Nombre
        {
            get => _nombre;
            set
            {
                if (_nombre != value)
                {
                    _nombre = value;
                    NotifyPropertyChanged("Nombre");
                }
            }
        }

        private string _pista;

        public string Pista
        {
            get => _pista;
            set
            {
                if (_pista != value)
                {
                    _pista = value;
                    NotifyPropertyChanged("Pista");
                }
            }
        }



        private string _nivel;
        public string Nivel
        {
            get => _nivel;
            set
            {
                if (_nivel != value)
                {
                    _nivel = value;
                    NotifyPropertyChanged("Nivel");
                }
            }
        }

        private string _genero;
        public string Genero
        {
            get => _genero;
            set
            {
                if (_genero != value)
                {
                    _genero = value;
                    NotifyPropertyChanged("Genero");
                }
            }
        }

        public Peliculas(string imagen, string nombre, string pista, string nivel, string genero)
        {
            Imagen = imagen;
            Nombre = nombre;
            Pista = pista;
            Nivel = nivel;
            Genero = genero;
        }

        public static List<Peliculas> listaPeliculas()
        {
            List<Peliculas> listaPeli = new List<Peliculas>();

            Peliculas peli1 = new Peliculas("https://i.pinimg.com/originals/b1/5c/84/b15c848ec8f0e0fead75062e8fa09b00.jpg", "Leon", "asesino con la flor", "facil", "Acción/drama");
            Peliculas peli2 = new Peliculas("https://oren-m7.ru/images/300/DSC100358454.jpg", "inception", "6 personas que tienen los mismos sueños", "medio", "Acción/Ciencia ficción");
            Peliculas peli3 = new Peliculas("https://image.tmdb.org/t/p/original/kKTPv9LKKs5L3oO1y5FNObxAPWI.jpg", "erase una vez en holywood", "victimas: Sharon tate", "dificil", "Comedia/Comedia dramática");
            
            listaPeli.Add(peli1);
            listaPeli.Add(peli2);
            listaPeli.Add(peli3);

            return listaPeli;

        }

        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
