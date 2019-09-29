using System.Linq;
using System.Collections.Generic;

namespace BitsoClient.RestApi.Parameters
{
    public class Params
    {
        public static string ToQueryString(params IParameter[] parameters)
        {
            IEnumerable<IParameter> notNullParams = parameters.Where(p => p.HasValue);
            return "?" + string.Join<IParameter>("&", notNullParams);
        }
    }
    
    
}