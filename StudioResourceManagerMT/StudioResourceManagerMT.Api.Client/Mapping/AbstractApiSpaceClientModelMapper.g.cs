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
    <Hash>a531725f865c2ff2beeb93b3bcf9ffcd</Hash>
</Codenesium>*/