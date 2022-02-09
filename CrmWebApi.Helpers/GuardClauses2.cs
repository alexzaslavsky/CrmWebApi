using System;

namespace CrmWebApi.Helpers
{
    public static class GuardClauses2
    {
        public static void IsNotNull(object argumentValue, string argumentName)
        {
            if (argumentValue == null)
                throw new ArgumentNullException(argumentName);
        }
    }
}
