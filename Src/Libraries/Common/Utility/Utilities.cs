using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Common.Utility
{
    public static class Utilities
    {
        [ExcludeFromCodeCoverage]
        public static object IsNull(object myValue, object myReplacement)
        {
            if ((!ReferenceEquals(myValue, DBNull.Value)))
            {
                if ((myValue != null))
                {
                    if (!(string.IsNullOrEmpty(myValue.ToString()))) //myValue.ToString() == string.Empty
                    {
                        return myValue;
                    }
                }
            }

            return myReplacement;
        }
    }
}
