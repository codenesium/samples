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

		POCOProductCostHistory Get(int productID);

		List<POCOProductCostHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>32d85c34d7fcd5ac1a720d50f4ebab15</Hash>
</Codenesium>*/