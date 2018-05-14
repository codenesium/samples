using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOChain
	{
		Task<CreateResponse<POCOChain>> Create(
			ChainModel model);

		Task<ActionResponse> Update(int id,
		                            ChainModel model);

		Task<ActionResponse> Delete(int id);

		POCOChain Get(int id);

		List<POCOChain> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOChain ExternalId(Guid externalId);
	}
}

/*<Codenesium>
    <Hash>10dd47e1d4abc7a54f8bd79a04f78076</Hash>
</Codenesium>*/