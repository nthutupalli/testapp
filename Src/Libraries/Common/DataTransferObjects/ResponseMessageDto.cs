/*
Copyright (C) Humana - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Firstname lastname <email@humana.com>, November 2021
*/


using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;


//Response Message DTo
//Response Message DTo

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
