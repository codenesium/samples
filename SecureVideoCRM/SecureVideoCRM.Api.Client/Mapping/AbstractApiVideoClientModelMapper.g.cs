using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Client
{
	public abstract class AbstractApiVideoModelMapper
	{
		public virtual ApiVideoClientResponseModel MapClientRequestToResponse(
			int id,
			ApiVideoClientRequestModel request)
		{
			var response = new ApiVideoClientResponseModel();
			response.SetProperties(id,
			                       request.Description,
			                       request.Title,
			                       request.Url);
			return response;
		}

		public virtual ApiVideoClientRequestModel MapClientResponseToRequest(
			ApiVideoClientResponseModel response)
		{
			var request = new ApiVideoClientRequestModel();
			request.SetProperties(
				response.Description,
				response.Title,
				response.Url);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>cf1b38d7a04660c22647d280b40bfe5e</Hash>
</Codenesium>*/