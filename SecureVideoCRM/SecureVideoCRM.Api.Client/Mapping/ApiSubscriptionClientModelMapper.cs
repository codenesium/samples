using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Client
{
	public class ApiSubscriptionModelMapper : IApiSubscriptionModelMapper
	{
		public virtual ApiSubscriptionClientResponseModel MapClientRequestToResponse(
			int id,
			ApiSubscriptionClientRequestModel request)
		{
			var response = new ApiSubscriptionClientResponseModel();
			response.SetProperties(id,
			                       request.Name,
			                       request.StripePlanName);
			return response;
		}

		public virtual ApiSubscriptionClientRequestModel MapClientResponseToRequest(
			ApiSubscriptionClientResponseModel response)
		{
			var request = new ApiSubscriptionClientRequestModel();
			request.SetProperties(
				response.Name,
				response.StripePlanName);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>4f01e1f3796769b616f3e80dbb31c57a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/