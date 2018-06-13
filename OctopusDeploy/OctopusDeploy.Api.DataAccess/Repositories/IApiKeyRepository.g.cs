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

                Task<List<ApiKey>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<ApiKey> GetApiKeyHashed(string apiKeyHashed);
        }
}

/*<Codenesium>
    <Hash>f8cc32f79663886649ca949955811cd9</Hash>
</Codenesium>*/