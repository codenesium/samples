using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IShipMethodService
	{
		Task<CreateResponse<ApiShipMethodServerResponseModel>> Create(
			ApiShipMethodServerRequestModel model);

		Task<UpdateResponse<ApiShipMethodServerResponseModel>> Update(int shipMethodID,
		                                                               ApiShipMethodServerRequestModel model);

		Task<ActionResponse> Delete(int shipMethodID);

		Task<ApiShipMethodServerResponseModel> Get(int shipMethodID);

		Task<List<ApiShipMethodServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiShipMethodServerResponseModel> ByName(string name);

		Task<ApiShipMethodServerResponseModel> ByRowguid(Guid rowguid);

		Task<List<ApiPurchaseOrderHeaderServerResponseModel>> PurchaseOrderHeadersByShipMethodID(int shipMethodID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>6820c27190633459d9bb947c0947ac6b</Hash>
</Codenesium>*/