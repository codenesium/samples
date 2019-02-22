using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public abstract class AbstractApiCallStatuModelMapper
	{
		public virtual ApiCallStatuClientResponseModel MapClientRequestToResponse(
			int id,
			ApiCallStatuClientRequestModel request)
		{
			var response = new ApiCallStatuClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiCallStatuClientRequestModel MapClientResponseToRequest(
			ApiCallStatuClientResponseModel response)
		{
			var request = new ApiCallStatuClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>4ae375bca1838e18fd1a7cf0c69763bf</Hash>
</Codenesium>*/