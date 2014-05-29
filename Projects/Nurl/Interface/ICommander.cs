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
<<<<<<< HEAD
        long LoadTime(string[] args);
        long LoadTimeAverage(string[] args);
=======
        void LoadTime(string[] args);
        void LoadTimeAverage(string[] args);
>>>>>>> ba203b89503b953f14b383286774297f32c27f87
        
    }
}
