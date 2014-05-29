using System;
using System.Net;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurl
{
    public class Nurl
    {
        static void Main(string[] args)
        {
            Commander consol = new Commander();
            if (args.Length > 0)
            {
                string operateur = args[0];
                switch (operateur)
                {
                    case "get":

                        if (args.Length == 3)
                            consol.Get(args);
                        else
                            consol.GetSave(args);
                        break;


                    case "test":

                        if (args.Length == 5)
                            consol.LoadTime(args);
                        else
                            consol.LoadTimeAverage(args);
                        break;

                    default:
                        Console.WriteLine("Erreur");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Aucun contenu dans le tableau argument");
            }
            Console.ReadKey();
        }
    }
}