using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public interface IBucketRepository
	{
		Task<POCOBucket> Create(ApiBucketModel model);

		Task Update(int id,
		            ApiBucketModel model);

		Task Delete(int id);

		Task<POCOBucket> Get(int id);

		Task<List<POCOBucket>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOBucket> Name(string name);
		Task<POCOBucket> ExternalId(Guid externalId);
	}
}

/*<Codenesium>
    <Hash>ab189c730f8739131b7a73f37f7768ba</Hash>
</Codenesium>*/