using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public abstract class AbstractApiClaspModelMapper
	{
		public virtual ApiClaspClientResponseModel MapClientRequestToResponse(
			int id,
			ApiClaspClientRequestModel request)
		{
			var response = new ApiClaspClientResponseModel();
			response.SetProperties(id,
			                       request.NextChainId,
			                       request.PreviousChainId);
			return response;
		}

		public virtual ApiClaspClientRequestModel MapClientResponseToRequest(
			ApiClaspClientResponseModel response)
		{
			var request = new ApiClaspClientRequestModel();
			request.SetProperties(
				response.NextChainId,
				response.PreviousChainId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>5d6fceef9556c0fb450b27401b717612</Hash>
</Codenesium>*/