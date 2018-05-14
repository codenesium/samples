using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOLink
	{
		Task<CreateResponse<POCOLink>> Create(
			LinkModel model);

		Task<ActionResponse> Update(int id,
		                            LinkModel model);

		Task<ActionResponse> Delete(int id);

		POCOLink Get(int id);

		List<POCOLink> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOLink> ChainId(int chainId);
		POCOLink ExternalId(Guid externalId);
	}
}

/*<Codenesium>
    <Hash>ad49b30c9466d5e89bc314df283abb47</Hash>
</Codenesium>*/