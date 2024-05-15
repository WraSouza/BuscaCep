using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BuscaCep.ViewModels
{
    abstract partial class BaseViewModel : ObservableObject
    {        
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool _IsBusy = false;
       
        public bool IsNotBusy => !_IsBusy;

    }
}
