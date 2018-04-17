using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOChainStatus
	{
		Task<CreateResponse<int>> Create(
			ChainStatusModel model);

		Task<ActionResponse> Update(int id,
		                            ChainStatusModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOChainStatus GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFChainStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOChainStatus> GetWhereDirect(Expression<Func<EFChainStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>23e4a72b3b1a381ba3f9f4a5f0583a46</Hash>
</Codenesium>*/