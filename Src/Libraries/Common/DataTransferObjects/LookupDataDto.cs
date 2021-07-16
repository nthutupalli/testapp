using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Common.DataTransferObjects
{
    [ExcludeFromCodeCoverage]
    public class LookupDataDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string functionCode { get; set; }
        public bool Active { get; set; }




    }
}
