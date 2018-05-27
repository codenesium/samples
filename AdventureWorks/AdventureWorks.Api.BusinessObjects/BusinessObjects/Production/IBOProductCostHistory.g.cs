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
		Task<CreateResponse<ApiProductCostHistoryResponseModel>> Create(
			ApiProductCostHistoryRequestModel model);

		Task<ActionResponse> Update(int productID,
		                            ApiProductCostHistoryRequestModel model);

		Task<ActionResponse> Delete(int productID);

		Task<ApiProductCostHistoryResponseModel> Get(int productID);

		Task<List<ApiProductCostHistoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1840befe34755d2bc9d29d6e16288d07</Hash>
</Codenesium>*/