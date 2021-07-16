using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Common.DataTransferObjects
{
    [ExcludeFromCodeCoverage]
    public class ResponseMessageDto
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public int ResponseId { get; set; }
    }
}
