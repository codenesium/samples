using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public abstract class AbstractApiSpaceModelMapper
	{
		public virtual ApiSpaceClientResponseModel MapClientRequestToResponse(
			int id,
			ApiSpaceClientRequestModel request)
		{
			var response = new ApiSpaceClientResponseModel();
			response.SetProperties(id,
			                       request.Description,
			                       request.Name);
			return response;
		}

		public virtual ApiSpaceClientRequestModel MapClientResponseToRequest(
			ApiSpaceClientResponseModel response)
		{
			var request = new ApiSpaceClientRequestModel();
			request.SetProperties(
				response.Description,
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>0132d60fcd6b4b95cae9f9b99ab087e8</Hash>
</Codenesium>*/