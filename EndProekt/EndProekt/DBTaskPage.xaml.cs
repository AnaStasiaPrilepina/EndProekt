using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EndProekt.Models;
using Task = EndProekt.Models.Task;

namespace EndProekt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DBTaskPage : ContentPage
    {
        public DBTaskPage()
        {
            InitializeComponent();
        }
        private void SaveTask(object sender, EventArgs e)
        {
            var task = (Task)BindingContext;
            if (!String.IsNullOrEmpty(task.Name))
            {
                App.Database.SaveItem(task);
            }
            this.Navigation.PopAsync();
        }
        private void DeleteTask (object secter, EventArgs e)
        {
            var task = (Task)BindingContext;
            App.Database.DeleteItem(task.Id);
            this.Navigation.PopAsync();
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}