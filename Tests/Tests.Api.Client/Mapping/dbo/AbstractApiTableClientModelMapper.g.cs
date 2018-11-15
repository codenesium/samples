using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Client
{
	public abstract class AbstractApiTableModelMapper
	{
		public virtual ApiTableClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTableClientRequestModel request)
		{
			var response = new ApiTableClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiTableClientRequestModel MapClientResponseToRequest(
			ApiTableClientResponseModel response)
		{
			var request = new ApiTableClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>145fad4f2005aeeac61604ec8cc8b671</Hash>
</Codenesium>*/