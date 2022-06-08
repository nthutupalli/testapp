/*
Copyright (C) Humana - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Firstname lastname <email@humana.com>, November 2021
*/

using System;

using System.Runtime.Serialization;


//Save Formulary Mapping DTO
//Save Formulary Mapping DTO

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
