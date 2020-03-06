using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class PrototypeTable
    {
        public int PrototypePk { get; set; }
        public int? PrototypeIntField { get; set; }
        public int OtherIntField { get; set; }
        public string PrototypeString { get; set; }
        public string OtherString { get; set; }
    }
}
