using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;

namespace Nurl
{
    public class Commander:ICommander
    {
        public void AfficherAide()
        {
            Console.WriteLine("Exemple d'utilisation");
            Console.WriteLine("Utilisez l'application de la manière suivante :");
            Console.WriteLine("nurl.exe get -url 'http://abc'");
            Console.WriteLine("nurl.exe get -url 'http://abc' -save 'c:\abc.json'");
            Console.WriteLine("nurl.exe test -url 'http://abc' -times 5");
            Console.WriteLine("nurl.exe test -url 'http://abc' -times 5 -avg");
            Console.WriteLine();
        }

        /// <summary> 
        /// afficher dans  la console le contenu du fichier situé à l'url abc
        /// nurl.exe get -url "http://abc"
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public void Get(string[] args)
        {
            //string action = args[0];
            if (!String.IsNullOrEmpty(args[0]))
            {
                //IArgument iarg = new Argument();
                //iarg.AddArgumentCouple(args[0], args[1]);

                using (WebClient client = new WebClient())
                {
                    string codeHtml = client.DownloadString(Normalisation(args[2]));
                    Console.WriteLine(codeHtml);
                }
            }
        }


        /// <summary>
        /// Sauvegarde le contenu de l'url http://abc dans le fichier c:\abc.json:
        /// nurl.exe get -url "http://abc" -save "c:\abc.json"
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>

        public void GetSave(string[] args)
        {
            if(!String.IsNullOrEmpty(args[0]))
            {
                using(WebClient client = new WebClient())
                {
                    //string a = 
                    client.DownloadFile(Normalisation(args[2]),Normalisation(args[4]));
                }
            }
        }
        
        /// <summary>
        /// Teste le temps de chargement du ficher à l'url http://abc 5 fois et affiche les 5 temp
        /// nurl.exe test -url "http://abc" -times 5
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>

        public void LoadTime(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            if (!String.IsNullOrEmpty(args[0]))
            {
                for (int i = 0; i <= int.Parse(args[4]); i++)
                {
                    sw.Reset();
                    sw.Start();
                    //Get(args);
                    using (WebClient client = new WebClient())
                    {
                        string codeHtml = client.DownloadString(Normalisation(args[2]));
                        Console.WriteLine(codeHtml);
                    }
                    sw.Stop();
                    Console.WriteLine(sw.ElapsedMilliseconds);
                }
            }
        }

        /// <summary>
        /// Teste le temps de chargement du fichier à l'url http://abc et affiche la moyenne du temps de chargement
        ///  nurl.exe test -url "http://abc" -times 5 avg
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns> 
        public void LoadTimeAverage(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            long mesure = 0;
            long avg = 0;

            if (!String.IsNullOrEmpty(args[0]))
            {
                for (int i = 0; i <= int.Parse(args[4]); i++)
                {
                    sw.Reset();
                    sw.Start();
                    using (WebClient client = new WebClient())
                    {
                        string codeHtml = client.DownloadString(Normalisation(args[2]));
                    }
                    sw.Stop();

                    mesure += sw.ElapsedMilliseconds;
                    Console.WriteLine(sw.ElapsedMilliseconds);
                    avg = mesure / int.Parse(args[4]);
                }
                Console.WriteLine("Le temps moyen de chargement du fichier situé à "+args[2].ToString()+" est "+avg);
            }
        }

        ///<summary>
        ///Methode qui prend un string avec des cotes et enleve les codes
        ///</summary>
        ///<param name="arg></param>
        ///<returns></returns>
        public string Normalisation(string url)
        {
            return url.Trim(new Char[] {'"'});
        }

    }
}
