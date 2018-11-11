using Deputados.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Deputados
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EvolucaoGastosDeputado : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public EvolucaoGastosDeputado()
        {
            InitializeComponent();
        }

        public EvolucaoGastosDeputado(Int32 idDep, String nome, String mandato)
        {
            InitializeComponent();

            CarregaEvolucaoGastosDeputado(idDep, mandato);
            NomeParlamentar.Text = nome;
        }

        async void CarregaEvolucaoGastosDeputado(Int32 idDep, String mandato)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    ObservableCollection<Evolucao> listEvolucao = new ObservableCollection<Evolucao>();

                    Int16 inicioMan;
                    Int16 fimMan;
                    Int16.TryParse(mandato.Substring(0, 4), out inicioMan);
                    Int16.TryParse(mandato.Substring(5, 4), out fimMan);
                    while (inicioMan <= fimMan && inicioMan >= 2009 && inicioMan <= 2013)
                    {
                        var uri = "http://meucongressonacional.com/api/001/deputado/" + idDep + "/gastos/" + inicioMan++;
                        var result = await client.GetStringAsync(uri);
                        var posts = JsonConvert.DeserializeObject<List<Evolucao>>(result);

                        Double valor = posts.Sum(x => x.Valor);
                        if (valor > 0)
                            listEvolucao.Add(new Evolucao((inicioMan - 1) + "", valor));
                    }

                    listView.ItemsSource = listEvolucao;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
