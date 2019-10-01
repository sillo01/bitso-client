namespace BitsoClient.RestApi
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string Content { get; set; }
    }
}