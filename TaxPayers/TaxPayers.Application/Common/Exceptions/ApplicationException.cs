﻿using System.Globalization;

namespace TaxPayers.Application
{
    public class ApplicationException : Exception
    {
        public ApplicationException()
            : base()
        {
        }

        public ApplicationException(string message)
            : base(message)
        {
        }

        public ApplicationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ApplicationException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}