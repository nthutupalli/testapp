using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Common.DataTransferObjects
{
    [ExcludeFromCodeCoverage]
    public class SaveFormularyMappingDto
    {
        public Int16 Lob { get; set; }
        public int PlanYear { get; set; }
        public string FormularyId { get; set; }
        public string FormularyName { get; set; }
        public string UserId { get; set; }


    }
}
