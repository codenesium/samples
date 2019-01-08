using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Client
{
	public abstract class AbstractApiSelfReferenceModelMapper
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
    <Hash>de8b990b10249700d7866ca7fc43c5ef</Hash>
</Codenesium>*/