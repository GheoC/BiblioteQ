using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GheoBiblioteQ._Service;
using GheoBiblioteQ._Stores;

namespace GheoBiblioteQ.ViewModels
{
    internal class MainViewModel:ViewModelBase
    {
        private readonly NavigationStore navigationStore;

        public MainViewModel(NavigationStore navigationStore)
        {
            this.navigationStore = navigationStore;
        }

        public ViewModelBase CurrentViewModel => navigationStore.CurrentViewModel;

       

    }
}
