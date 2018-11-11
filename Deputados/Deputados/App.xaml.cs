using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Deputados
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new ListaDeputados());
            //MainPage = new NavigationPage(new FrequenciaDeputado(141463, "Nome Teste"));
            //MainPage = new NavigationPage(new ComissoesDeputado(141463, "Nome Teste"));
            //MainPage = new NavigationPage(new ProjLeiDeputado(141463, "Nome Teste"));
            //MainPage = new NavigationPage(new TiposGastosDeputado(141463, "Nome Teste"));
            //MainPage = new NavigationPage(new EvolucaoGastosDeputado(141463, "Nome Teste", "2009-2014"));
            //MainPage = new NavigationPage(new PrincipaisDespesasDeputados());
            

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
