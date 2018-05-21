using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ILinkRepository
	{
		Task<POCOLink> Create(ApiLinkModel model);

		Task Update(int id,
		            ApiLinkModel model);

		Task Delete(int id);

		Task<POCOLink> Get(int id);

		Task<List<POCOLink>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOLink>> ChainId(int chainId);
		Task<POCOLink> ExternalId(Guid externalId);
	}
}

/*<Codenesium>
    <Hash>46134445fdb5ae98e9ec4a26c63bd9a4</Hash>
</Codenesium>*/