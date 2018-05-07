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
		Task<CreateResponse<int>> Create(
			ProductCostHistoryModel model);

		Task<ActionResponse> Update(int productID,
		                            ProductCostHistoryModel model);

		Task<ActionResponse> Delete(int productID);

		POCOProductCostHistory Get(int productID);

		List<POCOProductCostHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a2233b17d5a7ea846656d46f857d4d54</Hash>
</Codenesium>*/