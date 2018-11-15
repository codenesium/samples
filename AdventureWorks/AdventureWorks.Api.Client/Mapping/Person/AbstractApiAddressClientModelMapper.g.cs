using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiAddressModelMapper
	{
		public virtual ApiAddressClientResponseModel MapClientRequestToResponse(
			int addressID,
			ApiAddressClientRequestModel request)
		{
			var response = new ApiAddressClientResponseModel();
			response.SetProperties(addressID,
			                       request.AddressLine1,
			                       request.AddressLine2,
			                       request.City,
			                       request.ModifiedDate,
			                       request.PostalCode,
			                       request.Rowguid,
			                       request.StateProvinceID);
			return response;
		}

		public virtual ApiAddressClientRequestModel MapClientResponseToRequest(
			ApiAddressClientResponseModel response)
		{
			var request = new ApiAddressClientRequestModel();
			request.SetProperties(
				response.AddressLine1,
				response.AddressLine2,
				response.City,
				response.ModifiedDate,
				response.PostalCode,
				response.Rowguid,
				response.StateProvinceID);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>7959054df91554cee490be85a51f5481</Hash>
</Codenesium>*/