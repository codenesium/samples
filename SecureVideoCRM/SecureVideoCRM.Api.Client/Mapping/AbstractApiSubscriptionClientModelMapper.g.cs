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
			                       request.Name);
			return response;
		}

		public virtual ApiSubscriptionClientRequestModel MapClientResponseToRequest(
			ApiSubscriptionClientResponseModel response)
		{
			var request = new ApiSubscriptionClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>7de8d092ad77dec1bb43fab7ff11c5ba</Hash>
</Codenesium>*/