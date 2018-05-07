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
		Task<CreateResponse<int>> Create(
			StateModel model);

		Task<ActionResponse> Update(int id,
		                            StateModel model);

		Task<ActionResponse> Delete(int id);

		POCOState Get(int id);

		List<POCOState> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>fb74c4048ee0099058f3ddbd76505c90</Hash>
</Codenesium>*/