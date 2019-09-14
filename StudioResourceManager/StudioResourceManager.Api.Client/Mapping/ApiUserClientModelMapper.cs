using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public class ApiUserModelMapper : IApiUserModelMapper
	{
		public virtual ApiUserClientResponseModel MapClientRequestToResponse(
			int id,
			ApiUserClientRequestModel request)
		{
			var response = new ApiUserClientResponseModel();
			response.SetProperties(id,
			                       request.Password,
			                       request.Username);
			return response;
		}

		public virtual ApiUserClientRequestModel MapClientResponseToRequest(
			ApiUserClientResponseModel response)
		{
			var request = new ApiUserClientRequestModel();
			request.SetProperties(
				response.Password,
				response.Username);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>ac01a312c4366926c000820451de80e6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/