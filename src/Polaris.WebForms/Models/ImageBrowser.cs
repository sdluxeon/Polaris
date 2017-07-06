using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Polaris.WebForms.Models
{

    public class ImageBrowser
    {
        public Observable<List<string>> Images { get; private set; }

        public Observable<string> SelectedImage { get; private set; }

        private DefaultMimeTypeResolver mimeTypes = new DefaultMimeTypeResolver();

        public ImageBrowser()
        {
            Images = new Observable<List<string>>(new List<string>());
            SelectedImage = new Observable<string>(null);
        }

        public Task Scan(string directory)
        {
            return Task.Run(() =>
             {
                 if (!Directory.Exists(directory))
                 {
                     Images = Images.Change(new List<string>());
                 }
                 string[] allfiles = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);

                 var status = ProgramStatus.Global.CreateNamedStatus("Scanning Files...");
                 var newImages = new List<string>();
                 foreach (var item in allfiles)
                 {
                     status.Change(new FileInfo(item).Name);
                     var fileBytes = File.ReadAllBytes(item);
                     var mimeType = mimeTypes.GetMimeType(fileBytes);
                     if (mimeType.StartsWith("image"))
                         newImages.Add(item);
                 }
                 Images = Images.Change(newImages);
                 SelectedImage = SelectedImage.Change(newImages.FirstOrDefault());
                 ProgramStatus.Global.Change("Scanning Complete!");
             });
        }

        public void Select(string image)
        {
            SelectedImage = SelectedImage.Change(image);
        }

        public void Next()
        {
            throw new NotImplementedException();
        }

        public void Previous()
        {
            throw new NotImplementedException();
        }
    }
}
