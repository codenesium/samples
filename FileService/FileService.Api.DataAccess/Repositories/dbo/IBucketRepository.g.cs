using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public interface IBucketRepository
	{
		Task<DTOBucket> Create(DTOBucket dto);

		Task Update(int id,
		            DTOBucket dto);

		Task Delete(int id);

		Task<DTOBucket> Get(int id);

		Task<List<DTOBucket>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOBucket> GetExternalId(Guid externalId);
		Task<DTOBucket> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>ed54ee9d424e09f604c897af57cfafa1</Hash>
</Codenesium>*/