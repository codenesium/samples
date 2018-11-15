using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiAddressTypeModelMapper
	{
		public virtual ApiAddressTypeClientResponseModel MapClientRequestToResponse(
			int addressTypeID,
			ApiAddressTypeClientRequestModel request)
		{
			var response = new ApiAddressTypeClientResponseModel();
			response.SetProperties(addressTypeID,
			                       request.ModifiedDate,
			                       request.Name,
			                       request.Rowguid);
			return response;
		}

		public virtual ApiAddressTypeClientRequestModel MapClientResponseToRequest(
			ApiAddressTypeClientResponseModel response)
		{
			var request = new ApiAddressTypeClientRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name,
				response.Rowguid);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>81ae3cdd56b09ea4812ec9429c2a635c</Hash>
</Codenesium>*/