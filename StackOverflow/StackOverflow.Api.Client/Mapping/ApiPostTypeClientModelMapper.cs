using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public class ApiPostTypeModelMapper : IApiPostTypeModelMapper
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
    <Hash>2c1c979d6e685b41cf21dc0cfb6225fe</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/