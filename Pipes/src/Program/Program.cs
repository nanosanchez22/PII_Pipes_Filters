using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using Ucu.Poo.Twitter;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture luke = provider.GetPicture(@"luke.jpg");
            IPicture beer = provider.GetPicture(@"beer.jpg");

            FilterBlurConvolution filterBlur = new FilterBlurConvolution();
            FilterGreyscale filterGrey = new FilterGreyscale();
            FilterNegative filterNegative = new FilterNegative();

            

            /*  
            //Ejercicio 1
            PipeNull pipeNull = new PipeNull();
            PipeSerial pipeNegative = new PipeSerial(filterNegative, pipeNull);
            PipeSerial pipeGrey = new PipeSerial(filterGrey, pipeNull);
            PipeSerial pipeBlur = new PipeSerial(filterBlur, pipeNull); 
            
            IPicture lukeNegative = pipeNegative.Send(luke);
            IPicture lukeGrey = pipeGrey.Send(luke);
            IPicture lukeBlur = pipeBlur.Send(luke);

            provider.SavePicture(lukeNegative, @"lukeNegative.jpg"); 
            provider.SavePicture(lukeGrey, @"lukeGrey.jpg"); 
            provider.SavePicture(lukeBlur, @"lukeBlur.jpg"); 

            */

/* 
            //Ejercicio 2
            FilterPersistencia filterPersistencia1 = new FilterPersistencia(@"lukePer1.jpg");
            FilterPersistencia filterPersistencia2 = new FilterPersistencia(@"lukePer2.jpg");

            PipeNull pipeNull = new PipeNull();

            // Publicar en Twitter
            FilterTwitter filterTwitter = new FilterTwitter(@"lukeAll.jpg");
            PipeSerial pipeTwitter = new PipeSerial(filterTwitter, pipeNull);

            PipeSerial pipeBlur2 = new PipeSerial(filterBlur, pipeTwitter);
            PipeSerial pipePersistencia2 = new PipeSerial(filterPersistencia2, pipeBlur2);
            PipeSerial pipeGrey2 = new PipeSerial(filterGrey, pipePersistencia2);
            PipeSerial pipePersistencia1 = new PipeSerial(filterPersistencia1, pipeGrey2);
            PipeSerial pipeNegative2 = new PipeSerial(filterNegative, pipePersistencia1);

            IPicture lukeAll = pipeNegative2.Send(luke);            
            //provider.SavePicture(lukeAll, @"lukeAll.jpg"); 
 */
            //Ejercicio 4

            string pathTwitter = @"tieneCaraPer.jpg";
            PipeNull pipeNull = new PipeNull();
            FilterPersistencia filterPersistencia = new FilterPersistencia(pathTwitter);
            FilterConditional filterConditional = new FilterConditional();
            FilterTwitter filterTwitter = new FilterTwitter(pathTwitter);

            //si no tiene cara
            PipeSerial pipeNegative = new PipeSerial(filterNegative, pipeNull);

            //si tiene cara
            PipeSerial pipeTwitter = new PipeSerial(filterTwitter, pipeNull);
            PipeSerial pipePer = new PipeSerial(filterPersistencia, pipeTwitter);

            //Conditional fork
            PipeConditionalFork pipeConditionalFork = new PipeConditionalFork(pipeTwitter, pipeNegative, filterConditional);

            PipeSerial pipeGrey = new PipeSerial(filterGrey, pipeConditionalFork);


            IPicture testFace1 = pipeGrey.Send(luke);
            IPicture testFace2 = pipeGrey.Send(beer);

            provider.SavePicture(testFace1, @"tieneCara.jpg");
            provider.SavePicture(testFace2, @"noTieneCara.jpg");



        }
    }
}
