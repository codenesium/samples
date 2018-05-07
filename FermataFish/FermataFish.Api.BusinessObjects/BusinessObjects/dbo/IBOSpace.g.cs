using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOSpace
	{
		Task<CreateResponse<int>> Create(
			SpaceModel model);

		Task<ActionResponse> Update(int id,
		                            SpaceModel model);

		Task<ActionResponse> Delete(int id);

		POCOSpace Get(int id);

		List<POCOSpace> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>61799dec226839c477554e2e3b3a06c2</Hash>
</Codenesium>*/