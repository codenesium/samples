using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiShipMethodServerModelMapper
	{
		public virtual ApiShipMethodServerResponseModel MapServerRequestToResponse(
			int shipMethodID,
			ApiShipMethodServerRequestModel request)
		{
			var response = new ApiShipMethodServerResponseModel();
			response.SetProperties(shipMethodID,
			                       request.ModifiedDate,
			                       request.Name,
			                       request.Rowguid,
			                       request.ShipBase,
			                       request.ShipRate);
			return response;
		}

		public virtual ApiShipMethodServerRequestModel MapServerResponseToRequest(
			ApiShipMethodServerResponseModel response)
		{
			var request = new ApiShipMethodServerRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name,
				response.Rowguid,
				response.ShipBase,
				response.ShipRate);
			return request;
		}

		public virtual ApiShipMethodClientRequestModel MapServerResponseToClientRequest(
			ApiShipMethodServerResponseModel response)
		{
			var request = new ApiShipMethodClientRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name,
				response.Rowguid,
				response.ShipBase,
				response.ShipRate);
			return request;
		}

		public JsonPatchDocument<ApiShipMethodServerRequestModel> CreatePatch(ApiShipMethodServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiShipMethodServerRequestModel>();
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
    <Hash>d7135a3dd09da4ecd0f70314823bcf38</Hash>
</Codenesium>*/