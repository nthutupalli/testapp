/*
Copyright (C) Humana - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Firstname lastname <email@humana.com>, November 2021
*/

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
