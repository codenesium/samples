using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public class ApiSpaceModelMapper : IApiSpaceModelMapper
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
    <Hash>247d737089cc7f94a67f8d504db48625</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/