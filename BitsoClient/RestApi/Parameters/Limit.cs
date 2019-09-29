using System;

namespace BitsoClient.RestApi.Parameters
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
                    throw new ArgumentOutOfRangeException($"Max allowed value is {MaxValue}");
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