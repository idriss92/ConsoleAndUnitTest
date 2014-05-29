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
    /// <summary>
    /// Implements ICommander Interface
    /// </summary>
    public class Commander : ICommander
    {



        Verification verifie = new Verification();

        /// <summary>
        /// Helps for User
        /// </summary>
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
        /// Show the code of a web page in the console
        /// nurl.exe get -url "http://abc"
        /// </summary>
        /// <para> How It works?
        /// <code>Nurl.exe get -url "http://www.yahoo.fr"</code>
        /// </para>
        /// <param name="args">string [] args</param>
        /// <returns>Code contents of the web page</returns>
        public string Get(string[] args)
        {
            string codeHtml = string.Empty;
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
        /// Save the contents of the code of a web page on the disk
        /// nurl.exe get -url "http://abc" -save "c:\abc.json"
        /// </summary>
        /// <para> How It works?
        /// <code>Nurl.exe get -url "http://www.yahoo.fr" -save "C\Users\Namespace\Documents\save.txt"</code>
        /// </para>
        /// <param name="args">Argument of cammand line as array</param>
        /// <returns>Nothing</returns>
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


        /// <summary>
        /// Check the load time of the showing content and Show the time
        /// </summary>
        /// <para> How It works?
        /// <code>Nurl.exe test -url "http://www.yahoo.fr" -times 5 </code>
        /// </para>
        /// <param name="args">Argument of command line as a array</param>
        /// <returns> A value of the load time of the content</returns>
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

                if (verifie.isUrL(args[2]))
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
        /// Check the load time of the showing content and Show the average
        /// </summary>
        /// <para> How It works?
        /// <code>Nurl.exe test -url "http://www.yahoo.fr" -times 5 avg</code>
        /// </para>
        /// <param name="args">Argument of cammand line as array</param>
        /// <returns>Return the average</returns> 
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

     

            if (!String.IsNullOrEmpty(args[0]) && args[3]=="-times")
            {
                if (!etat == verifie.isUrL(args[2]))
                {
                    for (int i = 0; i <= int.Parse(args[4]); i++)
                    {
                        sw.Restart();
                        using (WebClient client = new WebClient())
                        {
                            string codeHtml = client.DownloadString(args[2]);
                        }
                        sw.Stop();

                        mesure += sw.ElapsedMilliseconds;
                        avg = mesure / int.Parse(args[4]);
                    }
                }
                Console.WriteLine("Le temps moyen de chargement du fichier situé à " + args[2].ToString() + " est " + avg);
            }

            return avg;
        }

    }
}
