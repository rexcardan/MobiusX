using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiusX.Json
{
    public class Named
    {
        public string display_str { get; set; }

        public override string ToString()
        {
            return display_str;
        }
    }
}
