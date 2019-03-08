using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public abstract class AbstractApiPostHistoryTypesModelMapper
	{
		public virtual ApiPostHistoryTypesClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPostHistoryTypesClientRequestModel request)
		{
			var response = new ApiPostHistoryTypesClientResponseModel();
			response.SetProperties(id,
			                       request.RwType);
			return response;
		}

		public virtual ApiPostHistoryTypesClientRequestModel MapClientResponseToRequest(
			ApiPostHistoryTypesClientResponseModel response)
		{
			var request = new ApiPostHistoryTypesClientRequestModel();
			request.SetProperties(
				response.RwType);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>963f9683686b48a8a02fba2ec9660d4b</Hash>
</Codenesium>*/