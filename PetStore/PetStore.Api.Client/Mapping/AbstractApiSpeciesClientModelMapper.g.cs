using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Client
{
	public abstract class AbstractApiSpeciesModelMapper
	{
		public virtual ApiSpeciesClientResponseModel MapClientRequestToResponse(
			int id,
			ApiSpeciesClientRequestModel request)
		{
			var response = new ApiSpeciesClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiSpeciesClientRequestModel MapClientResponseToRequest(
			ApiSpeciesClientResponseModel response)
		{
			var request = new ApiSpeciesClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>f71c6a672672945b272c754447617443</Hash>
</Codenesium>*/