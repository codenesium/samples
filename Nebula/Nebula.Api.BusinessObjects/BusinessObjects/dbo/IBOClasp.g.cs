using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOClasp
	{
		Task<CreateResponse<int>> Create(
			ClaspModel model);

		Task<ActionResponse> Update(int id,
		                            ClaspModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOClasp GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFClasp, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOClasp> GetWhereDirect(Expression<Func<EFClasp, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8cdb28afe5d9365700f2f5562e0c1749</Hash>
</Codenesium>*/