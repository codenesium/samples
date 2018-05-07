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

		POCOClasp Get(int id);

		List<POCOClasp> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>32c9f3e18b40e8294fe456f6e364fe55</Hash>
</Codenesium>*/