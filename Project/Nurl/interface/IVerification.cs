using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurl
{
    /// <summary>
    /// Interface for check prototype
    /// </summary>
    public interface IVerification
    {
        /// <summary>
        /// Prototype for 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        string Normalisation(string url);

        /// <summary>
        /// Prototype of IsDirectory method
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        bool IsDirectory(string directory);
        
        /// <summary>
        /// Prototype of isUrl Method
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        bool isUrL(string url);
    }
}
