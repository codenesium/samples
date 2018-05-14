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
		Task<CreateResponse<POCOSpace>> Create(
			ApiSpaceModel model);

		Task<ActionResponse> Update(int id,
		                            ApiSpaceModel model);

		Task<ActionResponse> Delete(int id);

		POCOSpace Get(int id);

		List<POCOSpace> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6d88ec52df2e4baf29d31860de6ad8f1</Hash>
</Codenesium>*/