using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public abstract class AbstractApiOfficerCapabilityModelMapper
	{
		public virtual ApiOfficerCapabilityClientResponseModel MapClientRequestToResponse(
			int id,
			ApiOfficerCapabilityClientRequestModel request)
		{
			var response = new ApiOfficerCapabilityClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiOfficerCapabilityClientRequestModel MapClientResponseToRequest(
			ApiOfficerCapabilityClientResponseModel response)
		{
			var request = new ApiOfficerCapabilityClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>b16fb1367357be5cb64bfdcb80cd72a2</Hash>
</Codenesium>*/