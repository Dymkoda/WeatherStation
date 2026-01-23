using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Sensor
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public DateTime MeasurementDate { get; set; }

    }
}
