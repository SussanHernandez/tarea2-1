using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEje2_1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageVid : ContentPage
    {
        String pathVideo = "";
        public PageVid()
        {
            InitializeComponent();
        }

        private async void btngrabar_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("AVISO", "La cámara no está disponible.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
            {
                Name = "Vid01.mp4",
                Directory = "MyVideos"
            });

            if (file == null)
                return;

            await DisplayAlert("AVISO", "El video se ha guardado en: " + file.Path, "OK");

            // Obtener el nombre del archivo de video
            var fileName = Path.GetFileName(file.Path);

            // Establecer la ruta del archivo y el nombre en la clase Vid
            var vid = new Models.Vid
            {
                path = file.Path,
                FileName = fileName
            };

            videoV.Source = file.Path;
            pathVideo = file.Path;
        }


        private async void btnsalvar_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(pathVideo))
            {
                var respuesta = await App.BaseDatos.guardaVideos(new Models.Vid { path = pathVideo });
                if (respuesta == 1)
                {
                    await DisplayAlert("AVISO", "SE GUARDO EL VIDEO EN SQLite.", "OK");
                    videoV.Source = null;
                    pathVideo = "";
                }
                else
                {
                    await DisplayAlert("ALERTA", "ALGO FALLO AL GUARDAR A SQLite", "OK");
                }
            }
            else
            {
                await DisplayAlert("ALERTA", "No se Encontro la ruta de tu video Grabado!", "OK");
            }
        }

        private async void btnLista_Clicked(object sender, EventArgs e)
        {
            var listado = await App.BaseDatos.GetListVid();//LLENAR LA LISTAA
            if (listado != null)
            {
                if (listado.Count() > 0)
                {
                    await Navigation.PushAsync(new PageListVid());
                }
                else
                {
                    await DisplayAlert("ALERTA", "NO HAY ELEMENTOS EN TU LISTA", "OK");
                }
            }
            else
            {
                await DisplayAlert("ALERTA", "NO HAY ELEMENTOS EN TU LISTA", "OK");
            }
        }
    }
}