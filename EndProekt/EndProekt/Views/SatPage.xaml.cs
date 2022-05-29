using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EndProekt.ViewModels;

namespace EndProekt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SatPage : ContentPage
    {
        public SatPage()
        {
            InitializeComponent();
            BindingContext = new TasksListViewModel() { Navigation = this.Navigation };
        }
    }
}