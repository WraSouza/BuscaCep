using BuscaCep.ViewModels;
using System.Net.Http.Json;

namespace BuscaCep
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        BuscaCepViewModel ViewModel => (BuscaCepViewModel)BindingContext;

        public MainPage()
        {
            InitializeComponent();

            BindingContext = new BuscaCepViewModel();
           
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
                     
        }
    }

    class ViaCepDTO
    {
            public bool erro { get; set; }
            public string? cep { get; set; }
            public string? logradouro { get; set; }
            public string? complemento { get; set; }
            public string? bairro { get; set; }
            public string? localidade { get; set; }
            public string? uf { get; set; }
            public string? ibge { get; set; }
            public string? gia { get; set; }
            public string? ddd { get; set; }
            public string? siafi { get; set; }
        

    }

}
