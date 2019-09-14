using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public class ApiTagModelMapper : IApiTagModelMapper
	{
		public virtual ApiTagClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTagClientRequestModel request)
		{
			var response = new ApiTagClientResponseModel();
			response.SetProperties(id,
			                       request.Count,
			                       request.ExcerptPostId,
			                       request.TagName,
			                       request.WikiPostId);
			return response;
		}

		public virtual ApiTagClientRequestModel MapClientResponseToRequest(
			ApiTagClientResponseModel response)
		{
			var request = new ApiTagClientRequestModel();
			request.SetProperties(
				response.Count,
				response.ExcerptPostId,
				response.TagName,
				response.WikiPostId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>9e7204160265ea64ca326c41087dee64</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/