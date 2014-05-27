using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurl
{
    public interface ICommander
    {
        string Get(string[] args);
        void GetSave(string[] args);
        void LoadTime(string[] args);
        void LoadTimeAverage(string[] args);
        
    }
}
