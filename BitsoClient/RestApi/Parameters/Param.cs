
namespace BitsoClient.RestApi.Parameters
{
    public class Params
    {
        public static string ToQueryString(params IParameter[] parameters)
        {
            return "?" + string.Join<IParameter>("&", parameters);
        }
    }
    
    
}