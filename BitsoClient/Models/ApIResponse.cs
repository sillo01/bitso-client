namespace BitsoClient.Models
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Payload { get; set; }
        public Error Error { get; set; }
    }
}