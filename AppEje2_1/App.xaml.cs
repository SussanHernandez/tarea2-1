using AppEje2_1.Controllers;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEje2_1
{
    public partial class App : Application
    {
        static BD database;
        public static BD BaseDatos
        {
            get
            {
                if (database == null)
                {
                    database = new BD(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "db_video_path.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.PageVid());
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
