using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Client
{
	public abstract class AbstractApiUserModelMapper
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
    <Hash>697678eb9de34c438070b0285f3525cf</Hash>
</Codenesium>*/