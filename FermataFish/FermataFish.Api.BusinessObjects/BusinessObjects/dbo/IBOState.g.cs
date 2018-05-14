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

		POCOState Get(int id);

		List<POCOState> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8e7c2851c79ffc6b30690cb9946a71d0</Hash>
</Codenesium>*/