using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurl
{
    /// <summary>
    /// Interface des arguments passés en ligne de commande
    /// </summary>
    public interface IArgument
    {
        /// <summary>
        /// Method for insert a key and his value in a dictionnary 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void AddArgumentCouple(string key, string value);

        /// <summary>
        /// Method for get the key of a value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        string GetKey(string value);

        /// <summary>
        /// Method for get the value of a key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetValue(string key);
    }
}
