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

                Task<ApiKey> GetApiKeyHashed(string apiKeyHashed);
        }
}

/*<Codenesium>
    <Hash>7848e0b06ac685ecef9fb6d6f72c3965</Hash>
</Codenesium>*/