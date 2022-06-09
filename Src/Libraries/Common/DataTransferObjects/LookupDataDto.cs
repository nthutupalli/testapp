/*
Copyright (C) Humana - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Firstname lastname <email@humana.com>, November 2021
*/



using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

//Look up Dto
//Look up Dto

namespace Common.DataTransferObjects
{
    [ExcludeFromCodeCoverage]
    public class LookupDataDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string functionCode { get; set; }
        [DataMember]
        public bool Active { get; set; }




    }
}
