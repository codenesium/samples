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
		Task<CreateResponse<POCORate>> Create(
			ApiRateModel model);

		Task<ActionResponse> Update(int id,
		                            ApiRateModel model);

		Task<ActionResponse> Delete(int id);

		POCORate Get(int id);

		List<POCORate> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>287d0809960febda2af54dd59b92151d</Hash>
</Codenesium>*/