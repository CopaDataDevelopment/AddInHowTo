using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddinWCFService
{
    public class VariableData
    {
        public string VariableId { get; set; }
        public string Name { get; set; }
        public string ProjectName { get; set; }
        public string ProjectGuid { get; set; }
        public string State { get; set; }
        public object Value { get; set; }
        public string Type { get; set; }
        public DateTime TimestampSeconds { get; set; }
        public Int16 TimestampMilliseconds { get; set; }
        public string Unit { get; set; }
        public string Identification { get; set; }

    }
}
