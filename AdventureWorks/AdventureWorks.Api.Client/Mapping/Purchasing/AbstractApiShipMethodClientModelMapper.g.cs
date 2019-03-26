using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiShipMethodModelMapper
	{
		public virtual ApiShipMethodClientResponseModel MapClientRequestToResponse(
			int shipMethodID,
			ApiShipMethodClientRequestModel request)
		{
			var response = new ApiShipMethodClientResponseModel();
			response.SetProperties(shipMethodID,
			                       request.ModifiedDate,
			                       request.Name,
			                       request.Rowguid,
			                       request.ShipBase,
			                       request.ShipRate);
			return response;
		}

		public virtual ApiShipMethodClientRequestModel MapClientResponseToRequest(
			ApiShipMethodClientResponseModel response)
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
	}
}

/*<Codenesium>
    <Hash>d9cc1f71d838845d499b9a003883fcf8</Hash>
</Codenesium>*/