using System;
using System.Drawing;
using Ucu.Poo.Cognitive;


namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y la guarda.
    /// </remarks>
    public class FilterConditional : IFilterConditional
    {
/*         public string Path {get;}
        public PictureProvider Provider {get;}
        public FilterConditional(string path){

            Path = path;
            Provider = new PictureProvider();

        } */
        /// Un filtro que guarda la imagen recibida.
        /// </summary>
        /// <param name="image">La imagen a la cual se le va a aplicar el filtro.</param>
        /// <returns>La imagen recibida.</returns>
        /* public IPicture Filter(IPicture image)
        {
            bool hasFace = FilterCon(image)


            //Provider.SavePicture(image, Path);
            //twitter.PublishToTwitter("prueba", Path);

            
            return image;            
        }  */


        public bool FilterCon(IPicture image)
        {
            CognitiveFace cog = new CognitiveFace(true, Color.GreenYellow);
            PictureProvider pictureProvider = new PictureProvider();
            string path = @"../../fotoFilterCon.jpg";
            pictureProvider.SavePicture(image,path);
            cog.Recognize(path);

            if (cog.FaceFound)
            {
                Console.WriteLine("Face Found!");
                return true;
            }
            else
            {
                Console.WriteLine("No Face Found");
                return false;
            }          
        }
    }
}
