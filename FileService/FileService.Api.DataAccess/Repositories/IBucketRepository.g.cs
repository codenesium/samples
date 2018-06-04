using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.DataAccess
{
	public interface IBucketRepository
	{
		Task<Bucket> Create(Bucket item);

		Task Update(Bucket item);

		Task Delete(int id);

		Task<Bucket> Get(int id);

		Task<List<Bucket>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<Bucket> GetExternalId(Guid externalId);
		Task<Bucket> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>94582d431c5adc67da5ce2ab3c3e12f8</Hash>
</Codenesium>*/