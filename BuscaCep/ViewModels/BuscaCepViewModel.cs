using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
    partial class BuscaCepViewModel : BaseViewModel
    {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(BuscarCommand))]
        string? _CEP;

        ViaCepDTO? _dto = null;

        public string? Logradouro { get => _dto?.logradouro; }
    
        public string? Bairro { get => _dto?.bairro; }
       
        public string? Localidade { get => _dto?.localidade; }
       
        public string? UF { get => _dto?.uf; }
       
        public string? DDD { get => _dto?.ddd; }      

       
        private bool BuscarCanExecute()
            => !string.IsNullOrWhiteSpace(CEP) &&
            CEP.Length == 8 &&
            IsNotBusy;

        [RelayCommand(CanExecute = nameof(BuscarCanExecute))]
        private async Task Buscar()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;               

                _dto = await new HttpClient().GetFromJsonAsync<ViaCepDTO>($"https://viacep.com.br/ws/{CEP}/json/") ??
                    throw new InvalidOperationException("Algo de Errado Não Está Certo");

                    if (_dto.erro)                    
                        throw new InvalidOperationException("Você Precisa Informar o CEP");                   
                    
                
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Ops", ex.Message, "OK");
            }
            finally
            {
                OnPropertyChanged(nameof(Logradouro));
                OnPropertyChanged(nameof(Bairro));
                OnPropertyChanged(nameof(Localidade));
                OnPropertyChanged(nameof(UF));
                OnPropertyChanged(nameof(DDD));

                IsBusy = false;
                BuscarCommand.NotifyCanExecuteChanged();
            }
        }

    
    }
}
