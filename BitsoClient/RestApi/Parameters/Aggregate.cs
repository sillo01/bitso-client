namespace BitsoClient.RestApi.Parameters
{
    public class Aggregate : BaseParameter<bool>
    {
        public Aggregate(bool? value) : base("aggregate")
        {
            Value = value ?? true;
            HasValue = value.HasValue;
        }

        public override string ToString()
        {
            return HasValue ? $"{Name}={Value.ToString()}" : ""; 
        }
    }
}