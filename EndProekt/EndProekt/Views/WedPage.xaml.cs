using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EndProekt.ViewModels;
using Task = EndProekt.Models.Task;

namespace EndProekt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WedPage : ContentPage
    {
        public WedPage()
        {
            InitializeComponent();
            //BindingContext = new TasksListViewModel() { Navigation = this.Navigation };
        }

        protected override void OnAppearing()
        {
            tasksList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Task selectedTask = (Task)e.SelectedItem;
            DBTaskPage taskPage = new DBTaskPage();
            taskPage.BindingContext = selectedTask;
            await Navigation.PushAsync(taskPage);
        }
        private async void CreateTask(object sender, EventArgs e)
        {
            Task task = new Task();
            DBTaskPage taskPage = new DBTaskPage();
            taskPage.BindingContext = task;
            await Navigation.PushAsync(taskPage);
        }
    }
}