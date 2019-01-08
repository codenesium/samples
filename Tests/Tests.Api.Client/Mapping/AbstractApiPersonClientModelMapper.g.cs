using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Client
{
	public abstract class AbstractApiPersonModelMapper
	{
		public virtual ApiPersonClientResponseModel MapClientRequestToResponse(
			int personId,
			ApiPersonClientRequestModel request)
		{
			var response = new ApiPersonClientResponseModel();
			response.SetProperties(personId,
			                       request.PersonName);
			return response;
		}

		public virtual ApiPersonClientRequestModel MapClientResponseToRequest(
			ApiPersonClientResponseModel response)
		{
			var request = new ApiPersonClientRequestModel();
			request.SetProperties(
				response.PersonName);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>1a5711681e9a6dfe124b0b4fd61c3b29</Hash>
</Codenesium>*/