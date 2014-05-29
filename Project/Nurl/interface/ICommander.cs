using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurl
{
    /// <summary>
    /// Interface Regroupant les prototypes à utiliser
    /// </summary>
    public interface ICommander
    {
        /// <summary>
        /// Prototype of Get Method
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        string Get(string[] args);

        /// <summary>
        /// Prototype of GetSave method
        /// </summary>
        /// <param name="args"></param>
        void GetSave(string[] args);

        /// <summary>
        /// Prototype of LoadTime method
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        long LoadTime(string[] args);

        /// <summary>
        /// Prototype of LoadTimeAverage Method
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        long LoadTimeAverage(string[] args);

    }
}
