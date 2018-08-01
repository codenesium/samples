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
    <Hash>57a0f9a25264566e783a77d3837b6473</Hash>
</Codenesium>*/