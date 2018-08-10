using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IApiKeyRepository
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
    <Hash>cd8715d57ff69d7c1af482d1a7ef9fd3</Hash>
</Codenesium>*/