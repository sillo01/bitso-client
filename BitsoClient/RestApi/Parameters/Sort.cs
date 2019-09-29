using System;
using System.Linq;

namespace BitsoClient.RestApi.Parameters
{
    public class Sort : BaseParameter<string>
    {
        private readonly string[] ValidValues = { "asc", "desc" };
        public Sort(string value) : base("sort")
        {
            HasValue = !string.IsNullOrEmpty(value);
            if (HasValue)
            {
                if (!ValidValues.Contains(value))
                {
                    throw new ArgumentException("Parameter 'sort' should have value 'asc' or 'desc'");
                }
                Value = value;
            }
        }

        public override string ToString()
        {
            return HasValue ? $"{Name}={Value}" : "";
        }
    }
}