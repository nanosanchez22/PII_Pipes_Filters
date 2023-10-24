using System;
using System.Drawing;
using Ucu.Poo.Twitter;


namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y la publica en Twitter.
    /// </remarks>
    public class FilterTwitter : IFilter
    {
        public TwitterImage twitter = new TwitterImage();
        public string Path {get;}
        public PictureProvider Provider {get;}
        public FilterTwitter(string path){

            Path = path;
            Provider = new PictureProvider();

        }
        /// Un filtro que publica la imagen recibida.
        /// </summary>
        /// <param name="image">La imagen a la cual se le va a aplicar el filtro.</param>
        public IPicture Filter(IPicture image)
        {
            Provider.SavePicture(image, Path);
            twitter.PublishToTwitter("prueba", Path);
            Console.WriteLine("Publicado en Twitter");
            return image;            
        }
    }
}
