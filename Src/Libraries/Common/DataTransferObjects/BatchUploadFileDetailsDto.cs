using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Common.DataTransferObjects
{
    public class BatchUploadFileDetailsDto
    {

        /// <summary>
        /// File Name
        /// </summary>
        [DataMember]
        public string FileName { get; set; }

        /// <summary>
        /// File Name
        /// </summary>
        [DataMember]
        public string FTPPathName { get; set; }

        /// <summary>
        /// Policy Type
        /// </summary>
        [DataMember]
        public int PolicyTypeId { get; set; }

        /// <summary>
        /// FileStatus
        /// </summary>
        [DataMember]
        public string FileStatus { get; set; }

        /// <summary>
        /// Action
        /// </summary>
        [DataMember]
        public string Action { get; set; }

        /// <summary>
        /// ErrorDescription
        /// </summary>
        [DataMember]
        public string ErrorDescription { get; set; }
        /// <summary>
        /// Active
        /// </summary>
        [DataMember]
        public Boolean Active { get; set; }

        /// <summary>
        /// Uploaded By
        /// </summary>
        [DataMember]
        public string UploadedBy { get; set; }
        /// <summary>
        /// Upload Date
        /// </summary>
        [DataMember]
        public string UploadDate { get; set; }
        /// <summary>
        /// Action By
        /// </summary>
        [DataMember]
        public string ActionBy { get; set; }
        /// <summary>
        /// Action Date
        /// </summary>
        [DataMember]
        public string ActionDate { get; set; }

    }
}
