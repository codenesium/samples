using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Client
{
	public class ApiUserModelMapper : IApiUserModelMapper
	{
		public virtual ApiUserClientResponseModel MapClientRequestToResponse(
			int userId,
			ApiUserClientRequestModel request)
		{
			var response = new ApiUserClientResponseModel();
			response.SetProperties(userId,
			                       request.BioImgUrl,
			                       request.Birthday,
			                       request.ContentDescription,
			                       request.Email,
			                       request.FullName,
			                       request.HeaderImgUrl,
			                       request.Interest,
			                       request.LocationLocationId,
			                       request.Password,
			                       request.PhoneNumber,
			                       request.Privacy,
			                       request.Username,
			                       request.Website);
			return response;
		}

		public virtual ApiUserClientRequestModel MapClientResponseToRequest(
			ApiUserClientResponseModel response)
		{
			var request = new ApiUserClientRequestModel();
			request.SetProperties(
				response.BioImgUrl,
				response.Birthday,
				response.ContentDescription,
				response.Email,
				response.FullName,
				response.HeaderImgUrl,
				response.Interest,
				response.LocationLocationId,
				response.Password,
				response.PhoneNumber,
				response.Privacy,
				response.Username,
				response.Website);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>36cc2e3d92ac44315297eb3dd2462f16</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/