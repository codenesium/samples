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
		Task<CreateResponse<POCOClasp>> Create(
			ApiClaspModel model);

		Task<ActionResponse> Update(int id,
		                            ApiClaspModel model);

		Task<ActionResponse> Delete(int id);

		POCOClasp Get(int id);

		List<POCOClasp> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6a6b84f0780a12f9839e8563fea487a4</Hash>
</Codenesium>*/