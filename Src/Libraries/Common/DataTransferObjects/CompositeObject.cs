/*
Copyright (C) Humana - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Firstname lastname <email@humana.com>, November 2021
*/

using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Common.DataTransferObjects
{
    
    public class CompositeObject
    {
        public class SaveCustomerClientMapping
        {
            [DataMember]
            public Collection<ArgusCustomerDto> ArgusCustomerDtoCollection { get; set; }
            [DataMember]
            public Collection<ArgusClientDto> ArgusClientDtoCollection { get; set; }
            [DataMember]
            public Int16 LobId { get; set; }
        }
        public class SaveRejectCodeMapping
        {
            private Collection<PolicyRejectCodeDto> policyRejectCodeCollection { get; set; }
            [DataMember]
            public Int16 policyTypeId { get; set; }
        }
        public class SelectedFormularies
        {
            [DataMember]
            public int planYear { get; set; }
            [DataMember]
            public int? lobId { get; set; }

        }
       
        public class LobValue
        {
            //LOBID
            [DataMember]
            public Int16 lobId { get; set; }
        }
        public class PoliyOwnerIdValue
        {
            //PolicyOwnerID
            [DataMember]
            public Int16 PoliyOwnerId { get; set; }
        }
        public class therapeuticCategoryIdIdValue
        {
            [DataMember]
            public Int16 therapeuticCategoryId { get; set; }
        }
        public class subCategoryIdValue
        {
            [DataMember]
            public Int16 subCategoryId { get; set; }
        }
        public class AvailableRejectCodes
        {
            [DataMember]
           
            public Int16 PolicyTypeId { get; set; }
        }
    }
}
