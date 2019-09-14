using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public class ApiOffCapabilityModelMapper : IApiOffCapabilityModelMapper
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
    <Hash>6a7a2bb4ab9e981c92c4eb4cb61759a8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/