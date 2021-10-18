using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DataTransferObjects
{
    public class PolicyStatusDto
    {
        public int PolicyStatusId { get; set; }
        public int StatusCode { get; set; }
        public string StatusName { get; set; }
    }
}
