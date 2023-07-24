using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEje2_1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListVid : ContentPage
    {
        public PageListVid()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listadoVideos.ItemsSource = await App.BaseDatos.GetListVid();//LLENAR LA LISTAA
        }
        private async void listadoVideos_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            Models.Vid aa = (Models.Vid)e.Item;
            String[] nom = aa.path.Split('/');
            String nom1 = nom[nom.Length - 1];
            PageReproductor rep = new PageReproductor();
            rep.BindingContext = aa;

            rep.Title = "Reproduciendo: " + nom1;

            //await CrossMediaManager.Current.Play(aa.path);
            await Navigation.PushAsync(rep);
        }
    }
}