using EndProekt.Models;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EndProekt
{
    public partial class App : Application
    {
        public const string DataBase_Name = "tasks.db";
        public static TaskRepository database;
        public static TaskRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new TaskRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DataBase_Name));
                }
                return database;
            }
        }
        //public App()
        //{
        //    InitializeComponent();

        //    MainPage = new NavigationPage(new DBListPage());
        //}
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
