using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Nurl
{
    /// <summary>
    /// Implements IVérification Interface
    /// </summary>
    public class Verification : IVerification
    {

        ///<summary>
        ///Erase the " of a string
        ///</summary>
        ///<param name="url">Url as String</param>
        ///<returns>A string without " </returns>
        public string Normalisation(string url)
        {
            return url.Trim(new Char[] { '"' });
        }

        /// <summary>
        /// Check if a string is a directory
        /// </summary>
        /// <param name="directory">Directory as string</param>
        /// <returns>A boolean value</returns>
        public bool IsDirectory(string directory)
        {
            return Directory.Exists(Path.GetFullPath(directory));
        }


        /// <summary>
        /// Check url statement
        /// </summary>
        /// <param name="url"></param>
        /// <returns>A boolean value</returns>
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

    }
}
