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
    public partial class PrincipaisDespesasDeputados : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }
        List<Deputado> listaDeputados = new List<Deputado>();

        public PrincipaisDespesasDeputados()
        {
            InitializeComponent();
            listaIdsDeputados();
        }

        async void listaIdsDeputados()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var uri = "http://meucongressonacional.com/api/001/deputado";
                    var result = await client.GetStringAsync(uri);
                    listaDeputados = JsonConvert.DeserializeObject<List<Deputado>>(result);
                    if(listaDeputados.Count > 0)
                        CarregaPrincipaisDespesas();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        async void CarregaPrincipaisDespesas()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    ObservableCollection<GastosCNPJ> listGastosCNPJ = new ObservableCollection<GastosCNPJ>();

                    foreach (Deputado d in listaDeputados)
                    {
                        var uri = "http://meucongressonacional.com/api/001/deputado/" + d.Id + "/gastos/cnpj";
                        var result = await client.GetStringAsync(uri);
                        var posts = JsonConvert.DeserializeObject<List<GastosCNPJ>>(result);


                        var qryGastos = posts
                            .GroupBy(x => x.Descricao)
                            .Select(g => new {
                                DescricaoGasto = g.Key,
                                Total = g.Sum(x => x.TotalGasto)
                            });

                        foreach (GastosCNPJ g in (ObservableCollection<GastosCNPJ>)qryGastos)
                        {
                            listGastosCNPJ.Add(g);
                        }
                        //int sda =0;
                        //Double valor = posts.Sum(x => x.Valor);
                        //if (valor > 0)
                        //    listGastosCNPJ.Add(new Evolucao((inicioMan - 1) + "", valor));
                    }

                    listView.ItemsSource = listGastosCNPJ;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
