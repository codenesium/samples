using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductInventory
	{
		Task<CreateResponse<ApiProductInventoryResponseModel>> Create(
			ApiProductInventoryRequestModel model);

		Task<ActionResponse> Update(int productID,
		                            ApiProductInventoryRequestModel model);

		Task<ActionResponse> Delete(int productID);

		Task<ApiProductInventoryResponseModel> Get(int productID);

		Task<List<ApiProductInventoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a02f0bb71c6c9dd1e86a62e734027395</Hash>
</Codenesium>*/