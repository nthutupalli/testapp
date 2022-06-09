/*
Copyright (C) Humana - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Firstname lastname <email@humana.com>, November 2021
*/

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
            if ((!ReferenceEquals(myValue, DBNull.Value)) && (myValue != null) && !(string.IsNullOrEmpty(myValue.ToString())))
            {
                return myValue;
            }

            return myReplacement;
        }
    }
}
