using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GheoBiblioteQ.ViewModels;

namespace GheoBiblioteQ.Views
{
    /// <summary>
    /// Interaction logic for PublisherView.xaml
    /// </summary>
    public partial class PublisherView : UserControl
    {
        private PublisherViewModel publisherViewModel;
        public PublisherView()
        {
            InitializeComponent();
            publisherViewModel = new PublisherViewModel();
            this.DataContext = publisherViewModel;
        }
    }
}
