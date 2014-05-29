using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Nurl
{
    public class Verification:IVerification
    {

        ///<summary>
        ///Methode qui prend un string avec des cotes et enleve les cotes
        ///</summary>
        ///<param name="arg></param>
        ///<returns></returns>
        public string Normalisation(string url)
        {
            return url.Trim(new Char[] { '"' });
        }

        /// <summary>
        /// Vérifie si un string est un repertoire
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        public bool IsDirectory(string directory)
        {
            return Directory.Exists(Path.GetFullPath(this.Normalisation(directory)));
        }

        /// <summary>
        /// Verifier si la chaine est un url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        /// 
        public bool isUrL(string url)
        {
            WebRequest webRequest = WebRequest.Create(url);
            WebResponse webResponse;
            try
            {
                webResponse = webRequest.GetResponse();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public string Replace (string chemin)
        {
            return chemin.Replace("\"", "/");
        }
    }
}
