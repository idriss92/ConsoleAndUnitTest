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
<<<<<<< HEAD
        ///Methode qui prend un string avec des cotes et enleve les cotes
=======
        ///Methode qui prend un string avec des cotes et enleve les codes
>>>>>>> ba203b89503b953f14b383286774297f32c27f87
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
<<<<<<< HEAD
            return Directory.Exists(Path.GetFullPath(this.Normalisation(directory)));
=======
            if (Directory.Exists(directory))
            {
                return true;
            }
            else
            {
                return false;
            }
>>>>>>> ba203b89503b953f14b383286774297f32c27f87
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

<<<<<<< HEAD
        public string Replace (string chemin)
        {
            return chemin.Replace("\"", "/");
        }
=======
        //public void Replace (string chemin)
        //{
        //    chemin.Replace("\"", "/");
        //}
>>>>>>> ba203b89503b953f14b383286774297f32c27f87
    }
}
