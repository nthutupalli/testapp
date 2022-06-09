/*
Copyright (C) Humana - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Firstname lastname <email@humana.com>, November 2021
*/



using System.Runtime.Serialization;


namespace Common.DataTransferObjects
{
    //Formulary Details DTO
    public class FormularyDetailsDto
    {
        [DataMember]
        public string UserFormId { get; set; }
        [DataMember]
        public string FormName { get; set; }
    }
}
