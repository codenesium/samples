using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiShipMethodModelMapper
	{
		public virtual ApiShipMethodResponseModel MapRequestToResponse(
			int shipMethodID,
			ApiShipMethodRequestModel request)
		{
			var response = new ApiShipMethodResponseModel();
			response.SetProperties(shipMethodID,
			                       request.ModifiedDate,
			                       request.Name,
			                       request.Rowguid,
			                       request.ShipBase,
			                       request.ShipRate);
			return response;
		}

		public virtual ApiShipMethodRequestModel MapResponseToRequest(
			ApiShipMethodResponseModel response)
		{
			var request = new ApiShipMethodRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name,
				response.Rowguid,
				response.ShipBase,
				response.ShipRate);
			return request;
		}

		public JsonPatchDocument<ApiShipMethodRequestModel> CreatePatch(ApiShipMethodRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiShipMethodRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.Rowguid, model.Rowguid);
			patch.Replace(x => x.ShipBase, model.ShipBase);
			patch.Replace(x => x.ShipRate, model.ShipRate);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>c4c2f7cfce7d996b90393104c7fc9d81</Hash>
</Codenesium>*/