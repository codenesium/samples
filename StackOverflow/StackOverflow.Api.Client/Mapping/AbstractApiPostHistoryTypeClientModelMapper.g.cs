using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public abstract class AbstractApiPostHistoryTypeModelMapper
	{
		public virtual ApiPostHistoryTypeClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPostHistoryTypeClientRequestModel request)
		{
			var response = new ApiPostHistoryTypeClientResponseModel();
			response.SetProperties(id,
			                       request.RwType);
			return response;
		}

		public virtual ApiPostHistoryTypeClientRequestModel MapClientResponseToRequest(
			ApiPostHistoryTypeClientResponseModel response)
		{
			var request = new ApiPostHistoryTypeClientRequestModel();
			request.SetProperties(
				response.RwType);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>fa7fc02dd34520a7ec9e0336a57fb60a</Hash>
</Codenesium>*/