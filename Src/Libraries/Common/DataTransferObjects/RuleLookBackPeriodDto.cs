namespace Common.DataTransferObjects
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// RuleLookBackPeriodDto
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class RuleLookBackPeriodDto
    {
        /// <summary>
        /// LookBackId
        /// </summary>
        public Int16 LookBackId { get; set; }

        /// <summary>
        /// LookBackValue
        /// </summary>
        public string LookBackValue { get; set; }

        /// <summary>
        /// LookBackUnit
        /// </summary>
        public string LookBackUnit { get; set; }

        /// <summary>
        /// ActionType
        /// </summary>
        public Constants.ActionType ActionType { get; set; }

        /// <summary>
        /// UpdatedBy
        /// </summary>
        public string UpdatedBy { get; set; }

        /// <summary>
        /// LookBackValueUnit
        /// </summary>
        public string LookBackValueUnit { get; set; }

        /// <summary>
        /// IsEditable
        /// </summary>
        public bool IsEditable { get; set; }
    }
}
