using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Deputados
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
           // ListaDeputados listaDeputados = new ListaDeputados();
            //Navigation.PushAsync(new ListaDeputados());
            // MainPage = new NavigationPage(new ListaDeputados());
           // viewListaDepotados();
        }

        private async void viewListaDepotados()
        {
            await Navigation.PushAsync(new ListaDeputados());
        }
    }
}
