using System;

namespace Common.Exceptions
{
    public class AjaxTimeoutException : Exception
    {
        public AjaxTimeoutException() { }

        public AjaxTimeoutException(string message) : base(message) { }

        public AjaxTimeoutException(string message, Exception inner) : base(message, inner) { }
    }
}
