using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Common.DataTransferObjects
{
    public class SaveFormularyMappingDto
    {
        [DataMember]
        public Int16 Lob { get; set; }
        [DataMember]
        public int PlanYear { get; set; }
        [DataMember]
        public string FormularyId { get; set; }
        [DataMember]
        public string FormularyName { get; set; }
        [DataMember]
        public string UserId { get; set; }


    }
}
