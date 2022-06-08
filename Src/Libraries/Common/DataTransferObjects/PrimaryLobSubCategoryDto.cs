/*
Copyright (C) Humana - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Firstname lastname <email@humana.com>, November 2021
*/

using System;
using System.Collections.Generic;
using System.Text;

//Primary Sub category DTO
//Primary Sub category DTO

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
