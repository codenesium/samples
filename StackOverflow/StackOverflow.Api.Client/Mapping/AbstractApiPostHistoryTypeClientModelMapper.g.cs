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
			                       request.Type);
			return response;
		}

		public virtual ApiPostHistoryTypeClientRequestModel MapClientResponseToRequest(
			ApiPostHistoryTypeClientResponseModel response)
		{
			var request = new ApiPostHistoryTypeClientRequestModel();
			request.SetProperties(
				response.Type);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>81774f72181a2881c9f002d3cb5151d1</Hash>
</Codenesium>*/