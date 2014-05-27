using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;
using System.IO;

namespace Nurl
{
    public class Commander : ICommander
    {

        

        Verification verifie = new Verification();

        public void AfficherAide()
        {
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
        /// <param name="arg">string [] args</param>
        /// <returns></returns>
        public string Get(string[] args)
        {
            string codeHtml = string.Empty ;
            if (!String.IsNullOrEmpty(args[0]))
            {
                IArgument iarg = new Argument();
                iarg.AddArgumentCouple(args[0], args[1]);

                IArgument iarg2 = new Argument();
                iarg2.AddArgumentCouple(args[1], args[2]);


                using (WebClient client = new WebClient())
                {
                    try
                    {
                        codeHtml = client.DownloadString(verifie.Normalisation(args[2]));
                        Console.WriteLine(codeHtml);
                    }

                    catch
                    {
                        Console.WriteLine("Error");
                    }
                }
            }
            return codeHtml;
        }


        /// <summary>
        /// Sauvegarde le contenu de l'url http://abc dans le fichier c:\abc.json:
        /// nurl.exe get -url "http://abc" -save "c:\abc.json"
        /// </summary>
        /// <param name="arg">string[] sargs</param>
        /// <returns></returns>
        public void GetSave(string[] args)
        {
            if (!String.IsNullOrEmpty(args[0]))
            {
                IArgument iarg = new Argument();
                //
                
                iarg.AddArgumentCouple(args[0], args[1]);

                IArgument iarg1 = new Argument();
                iarg1.AddArgumentCouple(args[1], args[2]);

                IArgument iarg2 = new Argument();
                iarg2.AddArgumentCouple(args[3], args[4]);

                bool etat = false;
                if (!etat == verifie.IsDirectory(args[4]))
                {
                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile(verifie.Normalisation(args[2]), verifie.Normalisation(args[4]));
                    }
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
                IArgument arg = new Argument();
                IArgument arg1 = new Argument();
                IArgument arg2 = new Argument();
                arg.AddArgumentCouple(args[0], args[1]);
                arg1.AddArgumentCouple(args[1], args[2]);
                arg2.AddArgumentCouple(args[3], args[4]);

                for (int i = 0; i <= int.Parse(args[4]); i++)
                {
                    sw.Reset();
                    sw.Start();
                    using (WebClient client = new WebClient())
                    {
                        string codeHtml = client.DownloadString(verifie.Normalisation(args[2]));
                        //Console.WriteLine(codeHtml);
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
            IArgument arg = new Argument();
            IArgument arg1 = new Argument();
            IArgument arg2 = new Argument();
            arg.AddArgumentCouple(args[0], args[1]);
            arg1.AddArgumentCouple(args[1], args[2]);
            arg2.AddArgumentCouple(args[4], args[5]);

            Stopwatch sw = new Stopwatch();
            long mesure = 0;
            long avg = 0;
            bool etat = false;

            

            if (!String.IsNullOrEmpty(args[0]))
            {
                if (!etat == verifie.isUrL(args[2]))
                {
                    for (int i = 0; i <= int.Parse(args[4]); i++)
                    {
                        sw.Reset();
                        sw.Start();
                        using (WebClient client = new WebClient())
                        {
                            string codeHtml = client.DownloadString(verifie.Normalisation(args[2]));
                        }
                        sw.Stop();

                        mesure += sw.ElapsedMilliseconds;
                        Console.WriteLine(sw.ElapsedMilliseconds);
                        avg = mesure / int.Parse(args[4]);
                    }
                }
                Console.WriteLine("Le temps moyen de chargement du fichier situé à " + args[2].ToString() + " est " + avg);
            }
        }

    }
}
