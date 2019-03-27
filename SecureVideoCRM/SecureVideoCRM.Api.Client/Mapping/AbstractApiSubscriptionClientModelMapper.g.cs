using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Client
{
	public abstract class AbstractApiSubscriptionModelMapper
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
    <Hash>a6220e5419125b17ef6b62d8eb4a6eb0</Hash>
</Codenesium>*/