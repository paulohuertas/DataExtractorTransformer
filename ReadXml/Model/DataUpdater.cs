using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadXml.Model
{
    public class DataUpdater
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }

        public DataUpdater(string name, string code, string value, string description)
        {
            Name = name;
            Code = code;
            Value = value;
            Description = description;
        }
    }
}
