using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ILinkRepository
	{
		Task<DTOLink> Create(DTOLink dto);

		Task Update(int id,
		            DTOLink dto);

		Task Delete(int id);

		Task<DTOLink> Get(int id);

		Task<List<DTOLink>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOLink> GetExternalId(Guid externalId);
		Task<List<DTOLink>> GetChainId(int chainId);
	}
}

/*<Codenesium>
    <Hash>6c37cffe599ef5ace11c7430a0e34b3c</Hash>
</Codenesium>*/