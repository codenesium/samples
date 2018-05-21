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

		Task<POCOAdmin> Get(int id);

		Task<List<POCOAdmin>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>2aa6667a324d60aa1d6f30181c393d52</Hash>
</Codenesium>*/