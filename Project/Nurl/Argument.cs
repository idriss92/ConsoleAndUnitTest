using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurl
{
    /// <summary>
    /// Implémentation de l'interface IArgument
    /// </summary>
    public class Argument : IArgument
    {
        /// <summary>
        /// Declare the dictionnary
        /// </summary>
        public Dictionary<string, string> values;

        /// <summary>
        /// Constructor
        /// </summary>
        public Argument()
        {
            values = new Dictionary<string, string>();
        }

        /// <summary>
        /// Add a key and a value in a dictionnary
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddArgumentCouple(string key, string value)
        {
            if (key == null || value == null)
                throw new ArgumentException();
            values.Add(key, value);
        }

        /// <summary>
        /// Get the key of a value stored in a dictionnary
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetKey(string value)
        {
            return values.First(k => k.Value == value).Key;

        }

        /// <summary>
        /// Get the value of a key stored in a dictionnary
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetValue(string key)
        {
            return values[key];
        }
    }
}
