namespace BitsoClient.RestApi.Parameters
{
    public class Marker : BaseParameter<int>
    {
        public Marker(int? value) : base("marker")
        {
            Value = value ?? default(int);
            HasValue = value.HasValue;
        }

        public override string ToString()
        {
            return HasValue ? $"{Name}={Value.ToString()}" : "";
        }
    }
}