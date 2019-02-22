using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public abstract class AbstractApiAddressModelMapper
	{
		public virtual ApiAddressClientResponseModel MapClientRequestToResponse(
			int id,
			ApiAddressClientRequestModel request)
		{
			var response = new ApiAddressClientResponseModel();
			response.SetProperties(id,
			                       request.Address1,
			                       request.Address2,
			                       request.City,
			                       request.State,
			                       request.Zip);
			return response;
		}

		public virtual ApiAddressClientRequestModel MapClientResponseToRequest(
			ApiAddressClientResponseModel response)
		{
			var request = new ApiAddressClientRequestModel();
			request.SetProperties(
				response.Address1,
				response.Address2,
				response.City,
				response.State,
				response.Zip);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>25b48e51af15945e601ab6b23a992b47</Hash>
</Codenesium>*/