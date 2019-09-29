using System;

namespace bitso_client.RestApi.Parameters
{
    public class Limit : BaseParameter<int>
    {
        private readonly int MaxValue = 100;
        public Limit(int? value) : base("limit")
        {
            HasValue = value.HasValue;
            if (HasValue)
            {
                if (value.Value > MaxValue)
                {
                    throw new ArgumentException($"Max allowed value is {MaxValue}");
                }
                Value = value.Value;
            }
        }

        public override string ToString()
        {
            return HasValue ? $"{Name}={Value.ToString()}" : "";
        }
    }
}