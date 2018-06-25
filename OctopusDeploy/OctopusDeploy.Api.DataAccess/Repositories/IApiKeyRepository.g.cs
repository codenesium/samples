using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IApiKeyRepository
        {
                Task<ApiKey> Create(ApiKey item);

                Task Update(ApiKey item);

                Task Delete(string id);

                Task<ApiKey> Get(string id);

                Task<List<ApiKey>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiKey> ByApiKeyHashed(string apiKeyHashed);
        }
}

/*<Codenesium>
    <Hash>3f5d28a605d2939d0da95c2760693d84</Hash>
</Codenesium>*/