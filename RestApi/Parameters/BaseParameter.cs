namespace bitso_client.RestApi.Parameters
{
    public abstract class BaseParameter<T>
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