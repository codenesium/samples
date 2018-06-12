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

                Task<List<ApiKey>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiKey> GetApiKeyHashed(string apiKeyHashed);
        }
}

/*<Codenesium>
    <Hash>b83e81077b89f93a964b84061126f1c4</Hash>
</Codenesium>*/