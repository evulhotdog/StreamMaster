using Microsoft.AspNetCore.Http;

using StreamMasterDomain.Common;

namespace StreamMasterInfrastructure.Middleware
{
    public interface ICacheableSpecification
    {
        bool IsCacheable(HttpRequest request);
    }

    public class CacheableSpecification : ICacheableSpecification
    {
        public bool IsCacheable(HttpRequest request)
        {
            if (BuildInfo.IsDebug)
            {
                return false;
            }

            if (request.Query.ContainsKey("h"))
            {
                return true;
            }

            if (request.Path.StartsWithSegments("/api", StringComparison.CurrentCultureIgnoreCase))
            {
                //if (request.Path.ToString().ContainsIgnoreCase("/MediaCover"))
                //{
                //    return true;
                //}

                return false;
            }

            if (request.Path.StartsWithSegments("/streammasterhub", StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }

            string path = request.Path.Value ?? "";

            if (path.EndsWith("/index.js"))
            {
                return false;
            }


            return true;
        }
    }
}
