using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface IProductCostHistoryService
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
    <Hash>cbd34a90ba5344d911872c2eab597475</Hash>
</Codenesium>*/