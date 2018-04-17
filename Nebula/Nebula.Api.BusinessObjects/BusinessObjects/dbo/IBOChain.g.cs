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

		ApiResponse GetById(int id);

		POCOChain GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFChain, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOChain> GetWhereDirect(Expression<Func<EFChain, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1bc3790f8ccfd1a4bda77a38f7baee58</Hash>
</Codenesium>*/