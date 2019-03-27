using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public abstract class AbstractApiOffCapabilityModelMapper
	{
		public virtual ApiOffCapabilityClientResponseModel MapClientRequestToResponse(
			int id,
			ApiOffCapabilityClientRequestModel request)
		{
			var response = new ApiOffCapabilityClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiOffCapabilityClientRequestModel MapClientResponseToRequest(
			ApiOffCapabilityClientResponseModel response)
		{
			var request = new ApiOffCapabilityClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>104561f274817f7aff43ed91d886f37f</Hash>
</Codenesium>*/