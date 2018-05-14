using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOAdmin
	{
		Task<CreateResponse<POCOAdmin>> Create(
			ApiAdminModel model);

		Task<ActionResponse> Update(int id,
		                            ApiAdminModel model);

		Task<ActionResponse> Delete(int id);

		POCOAdmin Get(int id);

		List<POCOAdmin> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>363408029082ca4f087ccbd49fbbb252</Hash>
</Codenesium>*/