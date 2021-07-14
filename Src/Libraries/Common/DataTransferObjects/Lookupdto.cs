using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Common.DataTransferObjects
{
    [ExcludeFromCodeCoverage]
    public class Lookupdto
    {
        public int Key { get; set; }
        public string Value { get; set; }
        public string LookupType { get; set; }



    }
}
