using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobiusX
{
    public class BeamDose
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double? ComputedDose { get; set; }

        public double? ComputedMU { get; set; }

        public double? TPSDose { get; set; }
    }
}
