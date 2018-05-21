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

		Task<POCOLink> GetExternalId(Guid externalId);
		Task<List<POCOLink>> GetChainId(int chainId);
	}
}

/*<Codenesium>
    <Hash>5471505040d88629e10a5e3ba714b3da</Hash>
</Codenesium>*/