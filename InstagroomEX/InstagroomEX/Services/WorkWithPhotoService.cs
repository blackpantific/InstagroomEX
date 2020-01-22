using Acr.UserDialogs;
using InstagroomEX.Contracts;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstagroomEX.Services
{
    public class WorkWithPhotoService : IWorkWithPhotoService
    {
        public async Task<string> TakePhoto()
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await UserDialogs.Instance.AlertAsync("No Camera", "No camera available", "OK");
                return String.Empty;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Test",
                SaveToAlbum = true,
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                PhotoSize = PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 2000,
                DefaultCamera = CameraDevice.Front
            });

            if (file == null)
                return String.Empty;
            return file.Path;

            //await UserDialogs.Instance.AlertAsync("File Location", file.Path, "OK");

            //image.Source = ImageSource.FromStream(() =>
            //{
            //    var stream = file.GetStream();
            //    file.Dispose();
            //    return stream;
            //});
        }

        async public Task<string> PickPhoto()
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await UserDialogs.Instance.AlertAsync("Photos Not Supported", "Permission not granted to photos", "OK");
                return String.Empty;
            }
            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,

            });

            if (file == null)
                return String.Empty;
            return file.Path;
            //PreviewImagePath = ImageSource.FromStream(() =>
            //{
            //    var stream = file.GetStream();
            //    file.Dispose();
            //    return stream;
            //});
        }

    }
}
