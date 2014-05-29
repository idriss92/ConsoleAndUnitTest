using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurl
{
    public class Argument : IArgument
    {
        public Dictionary<string, string> values;

        public Argument()
        {
            values = new Dictionary<string, string>();
        }

        public void AddArgumentCouple(string key, string value)
        {
            if (key == null || value == null)
                throw new ArgumentException();
            values.Add(key, value);
        }

        public string GetKey(string value)
        {
            return values.First(k => k.Value == value).Key;

        }

        public string GetValue(string key)
        {
            return values[key];
        }
    }
}
