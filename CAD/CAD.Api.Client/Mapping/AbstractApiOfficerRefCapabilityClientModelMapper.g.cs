using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public abstract class AbstractApiOfficerRefCapabilityModelMapper
	{
		public virtual ApiOfficerRefCapabilityClientResponseModel MapClientRequestToResponse(
			int id,
			ApiOfficerRefCapabilityClientRequestModel request)
		{
			var response = new ApiOfficerRefCapabilityClientResponseModel();
			response.SetProperties(id,
			                       request.CapabilityId,
			                       request.OfficerId);
			return response;
		}

		public virtual ApiOfficerRefCapabilityClientRequestModel MapClientResponseToRequest(
			ApiOfficerRefCapabilityClientResponseModel response)
		{
			var request = new ApiOfficerRefCapabilityClientRequestModel();
			request.SetProperties(
				response.CapabilityId,
				response.OfficerId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>8c058f665de856b0f4dcca92aa679285</Hash>
</Codenesium>*/