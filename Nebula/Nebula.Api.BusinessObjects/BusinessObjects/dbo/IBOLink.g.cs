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
			ApiLinkModel model);

		Task<ActionResponse> Update(int id,
		                            ApiLinkModel model);

		Task<ActionResponse> Delete(int id);

		POCOLink Get(int id);

		List<POCOLink> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOLink> ChainId(int chainId);
		POCOLink ExternalId(Guid externalId);
	}
}

/*<Codenesium>
    <Hash>4ddec293675517c3bb7b30e8f59ade3e</Hash>
</Codenesium>*/