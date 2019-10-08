namespace BitsoClient.Models
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public int Status { get; set; }
        public T Payload { get; set; }
    }
}