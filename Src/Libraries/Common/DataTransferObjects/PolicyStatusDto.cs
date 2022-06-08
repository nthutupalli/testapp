/*
Copyright (C) Humana - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Firstname lastname <email@humana.com>, November 2021
*/

using System;
using System.Collections.Generic;
using System.Text;
//Policy Status DTO
//Policy Status DTO

namespace Common.DataTransferObjects
{
    public class PolicyStatusDto
    {
        public int PolicyStatusId { get; set; }
        public int StatusCode { get; set; }
        public string StatusName { get; set; }
    }
}
