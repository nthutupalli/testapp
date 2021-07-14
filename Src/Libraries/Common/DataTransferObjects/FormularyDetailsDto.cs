using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Common.DataTransferObjects
{
    [ExcludeFromCodeCoverage]
    public class FormularyDetailsDto
    {
        public string UserFormId { get; set; }
        public string FormName { get; set; }
    }
}
