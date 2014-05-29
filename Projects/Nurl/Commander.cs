using System;
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
                    if (verifie.isUrL(args[2]))
                    {
                        try
                        {
                            codeHtml = client.DownloadString(args[2]);
                            Console.WriteLine(codeHtml);
                        }

                        catch
                        {
                            Console.WriteLine("Error");
                        }
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
                //IArgument iarg = new Argument();
                //iarg.AddArgumentCouple(args[0], args[1]);

                //IArgument iarg1 = new Argument();
                //iarg1.AddArgumentCouple(args[1], args[2]);

                //IArgument iarg2 = new Argument();
                //iarg2.AddArgumentCouple(args[3], args[4]);
                
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(args[2], args[4]);
                    //Console.Write("okokok");
                }
            }
        }

        ////public void GetSave(string[] args)
        ////{
        ////    if (!String.IsNullOrEmpty(args[0]))
        ////    {
        ////        using (WebClient client = new WebClient())
        ////        {
        ////            //Console.WriteLine(verifie.Normalisation(args[2]));
        ////            //Console.WriteLine(verifie.Normalisation(args[4]));
        ////            try
        ////            {
        ////                client.DownloadFile(verifie.Normalisation(args[2]), verifie.Normalisation(args[4]));
        ////                Console.WriteLine(Path.GetFileName(args[4]));
        ////            }
        ////            catch
        ////            {
        ////                Console.WriteLine("Probleme");
        ////            }
        ////        }
        ////    }
        ////}
        /// <summary>
        /// Teste le temps de chargement du ficher à l'url http://abc 5 fois et affiche les 5 temp
        /// Commande d'execution nurl.exe test -url "http://abc" -times 5
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public long LoadTime(string[] args)
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
                if (verifie.isUrL(verifie.Normalisation(args[2])))
                {
                    for (int i = 0; i < int.Parse(args[4]); i++)
                    {
                        sw.Restart();
                        using (WebClient client = new WebClient())
                        {
                            try
                            {
                                string codeHtml = client.DownloadString(args[2]);
                            }
                            catch
                            {
                                Console.WriteLine("erreur");
                            }
                        }
                        sw.Stop();
                        Console.WriteLine(sw.ElapsedMilliseconds);

                    }
                }
                else
                {
                    Console.WriteLine("Mauvais lien");
                }
            }

            return sw.ElapsedMilliseconds;
        }

        /// <summary>
        /// Teste le temps de chargement du fichier à l'url http://abc et affiche la moyenne du temps de chargement
        ///  Commande d'execution : nurl.exe test -url "http://abc" -times 5 avg
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns> 
        public long LoadTimeAverage(string[] args)
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
                            string codeHtml = client.DownloadString(args[2]);
                        }
                        sw.Stop();

                        mesure += sw.ElapsedMilliseconds;
                        Console.WriteLine(sw.ElapsedMilliseconds);
                        avg = mesure / int.Parse(args[4]);
                    }
                }
                Console.WriteLine("Le temps moyen de chargement du fichier situé à " + args[2].ToString() + " est " + avg);
            }

            return avg;
        }

    }
}
