using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public abstract class AbstractApiPostTypeModelMapper
	{
		public virtual ApiPostTypeClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPostTypeClientRequestModel request)
		{
			var response = new ApiPostTypeClientResponseModel();
			response.SetProperties(id,
			                       request.Type);
			return response;
		}

		public virtual ApiPostTypeClientRequestModel MapClientResponseToRequest(
			ApiPostTypeClientResponseModel response)
		{
			var request = new ApiPostTypeClientRequestModel();
			request.SetProperties(
				response.Type);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>0dd9922502540185d4fffaf42aaca130</Hash>
</Codenesium>*/