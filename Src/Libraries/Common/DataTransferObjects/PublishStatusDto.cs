using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Common.DataTransferObjects
{
    [ExcludeFromCodeCoverage]
    public class PublishStatusDto
    {
        public int PublishStatusId { get; set; }
        public string PublishStatusName { get; set; }
    }
}
