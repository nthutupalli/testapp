/*
Copyright (C) Humana - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Firstname lastname <email@humana.com>, November 2021
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;


namespace Common.DataTransferObjects
{
    /// <summary>
    /// Dto for Clinical Policy Search Functionality
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [ExcludeFromCodeCoverage]
    public class FormularyMappingDto
    {
        private List<int> lobId;
        private List<string> lobName;
        private List<int> planYear;
        private List<string> userFormId;
        private List<string> formName;



        /// <summary>
        /// LOBId
        /// </summary>
        [DataMember]
        public List<int> LOBId
        {
            get { return lobId ?? (lobId = new List<int>()); }
            set
            {
                lobId = value;
            }
        }

        /// <summary>
        /// LOBName
        /// </summary>
        [DataMember]
        public List<string> LOBName
        {
            get { return lobName ?? (lobName = new List<string>()); }
            set
            {
                lobName = value;
            }
        }

        /// <summary>
        /// FormName
        /// </summary>
        [DataMember]
        public List<string> FormName
        {
            get { return formName ?? (formName = new List<string>()); }
            set
            {
                formName = value;
            }
        }

        /// <summary>
        /// SelectedFormName
        /// </summary>
        [DataMember]
        public string SelectedFormName;




        /// <summary>
        /// PlanYear
        /// </summary>
        [DataMember]
        public List<int> PlanYear
        {
            get { return planYear ?? (planYear = new List<int>()); }
            set
            {
                planYear = value;
            }
        }

        /// <summary>
        /// UserId
        /// </summary>
        [DataMember]
        public string UserId;

        /// <summary>
        /// UserFormId
        /// </summary>
        [DataMember]
        public List<string> UserFormId
        {
            get { return userFormId ?? (userFormId = new List<string>()); }
            set
            {
                userFormId = value;
            }
        }

        /// <summary>
        /// SelectedUserFormId
        /// </summary>
        [DataMember]
        public  string SelectedUserFormId;

        [DataMember]
        public DataTable SlectedFormularyIds { get; set; }
    }

}
