namespace BitsoClient.RestApi.Parameters
{
    public interface IParameter
    {
        bool HasValue { get; set; }
    }
    public abstract class BaseParameter<T> : IParameter
    {
        public BaseParameter() {}
        public BaseParameter(string name, bool req = false)
        {
            Name = name;
            Required = req;
        }
        public string Name { get; set; }
        public bool Required { get; set; }
        public T Value { get; set; }
        public bool HasValue { get; set; }
    }
}