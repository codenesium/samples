using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOState
	{
		Task<CreateResponse<POCOState>> Create(
			ApiStateModel model);

		Task<ActionResponse> Update(int id,
		                            ApiStateModel model);

		Task<ActionResponse> Delete(int id);

		Task<POCOState> Get(int id);

		Task<List<POCOState>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1c572f3b7969f3567ea55c55d0b3aa5f</Hash>
</Codenesium>*/