using System;

namespace Common.Browsers
{
    public class BrowserNameAttribute : Attribute
    {
        public string NameValue { get; protected set; }

        public BrowserNameAttribute(string value)
        {
            this.NameValue = value;
        }
    }
}
