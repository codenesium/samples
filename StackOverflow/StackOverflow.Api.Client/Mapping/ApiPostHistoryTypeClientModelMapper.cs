using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public class ApiPostHistoryTypeModelMapper : IApiPostHistoryTypeModelMapper
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
    <Hash>8b10692120974e1fafce99806f86c46b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/