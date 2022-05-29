using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EndProekt
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            profileImage.Source = ImageSource.FromFile("koala.jpg");
            aboutList.ItemsSource = GetMenuList();
            var homePage = typeof(Views.HomePage);
            Detail = new NavigationPage((Page)Activator.CreateInstance(homePage));
            IsPresented = false;
        }

        public List<MasterMenuItems> GetMenuList()
        {
            var list = new List<MasterMenuItems>();
            list.Add(new MasterMenuItems()
            {
                Text = "Monday",
                Detail = "Esmaspäev",
                ImagePath = "mon.jpg",
                TargetPage = typeof(Views.MonPage)
            });
            list.Add(new MasterMenuItems()
            {
                Text = "Tuesday",
                Detail = "Teisipäev",
                ImagePath = "tue.jpg",
                TargetPage = typeof(Views.TuePage)
            });
            list.Add(new MasterMenuItems()
            {
                Text = "Wednesday",
                Detail = "Kolmapäev",
                ImagePath = "wed.jpg",
                TargetPage = typeof(Views.WedPage)
            });
            list.Add(new MasterMenuItems()
            {
                Text = "Thursday",
                Detail = "Neljapäev",
                ImagePath = "thu.jpg",
                TargetPage = typeof(Views.ThuPage)
            });
            list.Add(new MasterMenuItems()
            {
                Text = "Friday",
                Detail = "Reede",
                ImagePath = "fri.jpg",
                TargetPage = typeof(Views.FriPage)
            });
            list.Add(new MasterMenuItems()
            {
                Text = "Saturday",
                Detail = "Laupäev",
                ImagePath = "sat.jpg",
                TargetPage = typeof(Views.SatPage)
            });
            list.Add(new MasterMenuItems()
            {
                Text = "Sunday",
                Detail = "Pühapäev",
                ImagePath = "sun.jpg",
                TargetPage = typeof(Views.SunPage)
            });
            return list;
        }

        private void aboutList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedMenuItem = (MasterMenuItems)e.SelectedItem;
            Type selectedPage = selectedMenuItem.TargetPage;
            Detail = new NavigationPage((Page)Activator.CreateInstance(selectedPage));
            IsPresented = false;
        }
    }
}
