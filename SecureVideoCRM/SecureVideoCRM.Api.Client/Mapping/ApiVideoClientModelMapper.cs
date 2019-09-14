using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Client
{
	public class ApiVideoModelMapper : IApiVideoModelMapper
	{
		public virtual ApiVideoClientResponseModel MapClientRequestToResponse(
			int id,
			ApiVideoClientRequestModel request)
		{
			var response = new ApiVideoClientResponseModel();
			response.SetProperties(id,
			                       request.Description,
			                       request.Title,
			                       request.Url);
			return response;
		}

		public virtual ApiVideoClientRequestModel MapClientResponseToRequest(
			ApiVideoClientResponseModel response)
		{
			var request = new ApiVideoClientRequestModel();
			request.SetProperties(
				response.Description,
				response.Title,
				response.Url);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>ec704616ca6d758712799b7049840daf</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/