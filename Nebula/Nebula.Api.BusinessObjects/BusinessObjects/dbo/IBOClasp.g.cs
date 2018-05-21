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

		Task<POCOClasp> Get(int id);

		Task<List<POCOClasp>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>583a4576a6afe9b3ada4ded6aca150e3</Hash>
</Codenesium>*/