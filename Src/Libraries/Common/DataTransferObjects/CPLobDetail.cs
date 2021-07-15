using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Common.DataTransferObjects
{
    public class CPLobDetail
    {
        /// <summary>
        /// Line Of Business Name
        /// </summary>
        [DataMember]
        public string LobName { get; set; }

        /// <summary>
        /// LobCode
        /// </summary>
        [DataMember]
        public Int16 LobCode { get; set; }

        /// <summary>
        /// IsActive
        /// </summary>
        [DataMember]
        public Int16 IsActive { get; set; }

    }
}
