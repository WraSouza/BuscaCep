using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BuscaCep.ViewModels
{
    public class BuscaCepViewModel : BaseViewModel
    {
        private string? _CEP;

        private string? _Logradouro;
        public string? Logradouro
        {
            get => _Logradouro;
            set
            {
                _Logradouro = value;
                OnPropertyChanged();
            }
        }
        private string? _Bairro;
        public string? Bairro
        {
            get => _Bairro;
            set
            {
                _Bairro = value;
                OnPropertyChanged();
            }
        }
        private string? _Localidade;
        public string? Localidade
        {
            get => _Localidade;
            set
            {
                _Localidade = value;
                OnPropertyChanged();
            }
        }
        private string? _UF;
        public string? UF
        {
            get => _UF;
            set
            {
                _UF = value;
                OnPropertyChanged();
            }
        }

        private string? _DDD;
        public string? DDD 
        { get => _DDD;
            set {
                _DDD = value;
                OnPropertyChanged();
            } 
        }

        public string? CEP
        {
            get => _CEP;

            set
            {
                _CEP = value;
                OnPropertyChanged();
            }
        }

        private Command _BuscarCommand;

        public Command BuscarCommand
         => _BuscarCommand ??= new Command(async () => await BuscarCommandExecute());            
        

        private async Task BuscarCommandExecute()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(CEP))                
                 throw new InvalidOperationException("Você Precisa Informar o CEP");
                
                else
                {
                    var ViaCepResult = await new HttpClient().GetFromJsonAsync<ViaCepDTO>($"https://viacep.com.br/ws/{CEP}/json/");

                    if (ViaCepResult.erro)
                    {
                        throw new InvalidOperationException("Você Precisa Informar o CEP");
                    }

                    if (ViaCepResult is null)
                    throw new InvalidOperationException("Algo de Errado Não Está Certo");
                    
                    
                       Logradouro = ViaCepResult.logradouro;
                       Bairro = ViaCepResult.bairro;
                       Localidade = ViaCepResult.localidade;
                       UF = ViaCepResult.uf;
                       DDD = ViaCepResult?.ddd;
                    
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Ops", ex.Message, "OK");
            }
        }

    
    }
}
