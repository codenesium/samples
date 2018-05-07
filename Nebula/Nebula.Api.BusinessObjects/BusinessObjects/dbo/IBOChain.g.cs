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
		Task<CreateResponse<int>> Create(
			ChainModel model);

		Task<ActionResponse> Update(int id,
		                            ChainModel model);

		Task<ActionResponse> Delete(int id);

		POCOChain Get(int id);

		List<POCOChain> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>718df8c9296d3515a78e8d5262d979d0</Hash>
</Codenesium>*/