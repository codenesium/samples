using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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

                Task<ApiKey> GetApiKeyHashed(string apiKeyHashed);
        }
}

/*<Codenesium>
    <Hash>53a399c9744ebaf4ef93705c67cfb087</Hash>
</Codenesium>*/