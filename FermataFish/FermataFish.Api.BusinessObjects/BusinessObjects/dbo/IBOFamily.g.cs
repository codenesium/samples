using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOFamily
	{
		Task<CreateResponse<int>> Create(
			FamilyModel model);

		Task<ActionResponse> Update(int id,
		                            FamilyModel model);

		Task<ActionResponse> Delete(int id);

		POCOFamily Get(int id);

		List<POCOFamily> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>446d44dd0351c81038b09ee5a4ecc632</Hash>
</Codenesium>*/