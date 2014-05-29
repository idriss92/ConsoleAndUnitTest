using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurl
{
    public interface IVerification
    {
        string Normalisation(string url);
        bool IsDirectory(string directory);
        bool isUrL(string url);
    }
}
