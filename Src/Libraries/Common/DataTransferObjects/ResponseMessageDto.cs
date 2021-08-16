using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text;

namespace Common.DataTransferObjects
{
    [ExcludeFromCodeCoverage]
    public class ResponseMessageDto
    {
        [DataMember]
        public int Code { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public int ResponseId { get; set; }
    }
}
