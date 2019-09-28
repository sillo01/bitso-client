namespace bitso_client.Models
{
    public abstract class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Payload { get; set; }
    }
}