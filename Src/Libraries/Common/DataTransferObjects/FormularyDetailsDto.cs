using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Common.DataTransferObjects
{
    public class FormularyDetailsDto
    {
        [DataMember]
        public string UserFormId { get; set; }
        [DataMember]
        public string FormName { get; set; }
    }
}
