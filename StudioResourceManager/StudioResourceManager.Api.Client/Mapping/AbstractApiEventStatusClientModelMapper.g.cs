using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public abstract class AbstractApiEventStatusModelMapper
	{
		public virtual ApiEventStatusClientResponseModel MapClientRequestToResponse(
			int id,
			ApiEventStatusClientRequestModel request)
		{
			var response = new ApiEventStatusClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiEventStatusClientRequestModel MapClientResponseToRequest(
			ApiEventStatusClientResponseModel response)
		{
			var request = new ApiEventStatusClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>6b69231bdf38e9de6a14c46963a2620d</Hash>
</Codenesium>*/