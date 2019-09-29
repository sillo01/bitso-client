using System;

namespace BitsoClient.RestApi.Parameters
{
    public class Book : BaseParameter<string>
    {
        public Book(string value) : base("book", true)
        {
            if(Required && string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Parameter 'value' must have a value");
            }
            HasValue = true;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Name}={Value}";
        }
    }
}