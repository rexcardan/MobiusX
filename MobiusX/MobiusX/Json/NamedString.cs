using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiusX.Json
{
    public class NamedString : Named
    {
        public string value { get; set; }

        public override string ToString()
        {
            return value;
        }
    }
}
