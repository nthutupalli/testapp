using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DataTransferObjects
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract(Namespace = "")]
    public class PrimaryLobSubCategoryDto
    {
        [DataMember]
        public int PrimaryLobId { get; set; }
        [DataMember]
        public string PrimaryLobName { get; set; }
    }
}
