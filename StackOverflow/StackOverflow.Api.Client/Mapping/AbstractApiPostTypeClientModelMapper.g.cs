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
			                       request.RwType);
			return response;
		}

		public virtual ApiPostTypeClientRequestModel MapClientResponseToRequest(
			ApiPostTypeClientResponseModel response)
		{
			var request = new ApiPostTypeClientRequestModel();
			request.SetProperties(
				response.RwType);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>99b44085fff4917e72d0d6f106dc374a</Hash>
</Codenesium>*/