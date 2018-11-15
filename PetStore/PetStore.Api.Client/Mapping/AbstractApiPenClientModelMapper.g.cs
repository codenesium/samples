using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Client
{
	public abstract class AbstractApiPenModelMapper
	{
		public virtual ApiPenClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPenClientRequestModel request)
		{
			var response = new ApiPenClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiPenClientRequestModel MapClientResponseToRequest(
			ApiPenClientResponseModel response)
		{
			var request = new ApiPenClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>c25381ec4987cd7debb53982977f5374</Hash>
</Codenesium>*/