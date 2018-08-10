using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IProductInventoryService
	{
		Task<CreateResponse<ApiProductInventoryResponseModel>> Create(
			ApiProductInventoryRequestModel model);

		Task<UpdateResponse<ApiProductInventoryResponseModel>> Update(int productID,
		                                                               ApiProductInventoryRequestModel model);

		Task<ActionResponse> Delete(int productID);

		Task<ApiProductInventoryResponseModel> Get(int productID);

		Task<List<ApiProductInventoryResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>0f3127fabaa228e7560cfc2651c1dbd8</Hash>
</Codenesium>*/