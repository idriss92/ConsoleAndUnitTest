using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurl
{
    public interface IArgument
    {
        void AddArgumentCouple(string key, string value);
        string GetKey(string value);
        string GetValue(string key);
    }
}
