using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBORate
	{
		Task<CreateResponse<int>> Create(
			RateModel model);

		Task<ActionResponse> Update(int id,
		                            RateModel model);

		Task<ActionResponse> Delete(int id);

		POCORate Get(int id);

		List<POCORate> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1773f5687c8fbcb534e7ff7f02aadcf1</Hash>
</Codenesium>*/