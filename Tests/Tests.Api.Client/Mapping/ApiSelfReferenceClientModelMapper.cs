using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Client
{
	public class ApiSelfReferenceModelMapper : IApiSelfReferenceModelMapper
	{
		public virtual ApiSelfReferenceClientResponseModel MapClientRequestToResponse(
			int id,
			ApiSelfReferenceClientRequestModel request)
		{
			var response = new ApiSelfReferenceClientResponseModel();
			response.SetProperties(id,
			                       request.SelfReferenceId,
			                       request.SelfReferenceId2);
			return response;
		}

		public virtual ApiSelfReferenceClientRequestModel MapClientResponseToRequest(
			ApiSelfReferenceClientResponseModel response)
		{
			var request = new ApiSelfReferenceClientRequestModel();
			request.SetProperties(
				response.SelfReferenceId,
				response.SelfReferenceId2);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>d60f14a770718cf37c1b35e635abefb0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/