using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductCostHistory
	{
		Task<CreateResponse<POCOProductCostHistory>> Create(
			ApiProductCostHistoryModel model);

		Task<ActionResponse> Update(int productID,
		                            ApiProductCostHistoryModel model);

		Task<ActionResponse> Delete(int productID);

		Task<POCOProductCostHistory> Get(int productID);

		Task<List<POCOProductCostHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>96127bd753f32cc1f29cb397c58ac3bc</Hash>
</Codenesium>*/