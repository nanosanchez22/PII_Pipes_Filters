using System;
using System.Drawing;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y la guarda.
    /// </remarks>
    public class FilterPersistencia : IFilter
    {
        public string Path {get;}
        public PictureProvider Provider {get;}
        public FilterPersistencia(string path){

            Path = path;
            Provider = new PictureProvider();

        }
        /// Un filtro que guarda la imagen recibida.
        /// </summary>
        /// <param name="image">La imagen a la cual se le va a aplicar el filtro.</param>
        /// <returns>La imagen recibida.</returns>
        public IPicture Filter(IPicture image)
        {
            Provider.SavePicture(image, Path);
            return image;            
        }
    }
}
