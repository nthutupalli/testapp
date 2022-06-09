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
using System.Text;

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
        private IList<int> lobId;
        private IList<string> lobName;
        private IList<int> planYear;
        private IList<string> userFormId;
        private IList<string> formName;



        /// <summary>
        /// LOBId
        /// </summary>
        [DataMember]
        public IList<int> LOBId
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
        public IList<string> LOBName
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
        public IList<string> FormName
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
        private string SelectedFormName;




        /// <summary>
        /// PlanYear
        /// </summary>
        [DataMember]
        public IList<int> PlanYear
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
        private string UserId;

        /// <summary>
        /// UserFormId
        /// </summary>
        [DataMember]
        public IList<string> UserFormId
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
        private string SelectedUserFormId;

        [DataMember]
        public DataTable SlectedFormularyIds { get; set; }
    }

}
