using MediaManager;
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
    public partial class PageReproductor : ContentPage
    {
        public PageReproductor()
        {
            InitializeComponent();
        }

        protected async override void OnDisappearing()
        {
            base.OnDisappearing();
            await CrossMediaManager.Current.Stop();
        }
    }
}