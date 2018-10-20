using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IShipMethodService
	{
		Task<CreateResponse<ApiShipMethodResponseModel>> Create(
			ApiShipMethodRequestModel model);

		Task<UpdateResponse<ApiShipMethodResponseModel>> Update(int shipMethodID,
		                                                         ApiShipMethodRequestModel model);

		Task<ActionResponse> Delete(int shipMethodID);

		Task<ApiShipMethodResponseModel> Get(int shipMethodID);

		Task<List<ApiShipMethodResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiShipMethodResponseModel> ByName(string name);

		Task<List<ApiPurchaseOrderHeaderResponseModel>> PurchaseOrderHeadersByShipMethodID(int shipMethodID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>6f93af2fcf3987c0222d0d8e61fd4584</Hash>
</Codenesium>*/