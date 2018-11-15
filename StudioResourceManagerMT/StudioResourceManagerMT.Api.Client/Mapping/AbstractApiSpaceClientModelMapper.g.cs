using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
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
    <Hash>ba74ffb5ab91b425db85af02aedc3768</Hash>
</Codenesium>*/