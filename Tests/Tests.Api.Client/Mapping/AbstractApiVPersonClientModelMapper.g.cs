using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Client
{
	public abstract class AbstractApiVPersonModelMapper
	{
		public virtual ApiVPersonClientResponseModel MapClientRequestToResponse(
			int personId,
			ApiVPersonClientRequestModel request)
		{
			var response = new ApiVPersonClientResponseModel();
			response.SetProperties(personId,
			                       request.PersonName);
			return response;
		}

		public virtual ApiVPersonClientRequestModel MapClientResponseToRequest(
			ApiVPersonClientResponseModel response)
		{
			var request = new ApiVPersonClientRequestModel();
			request.SetProperties(
				response.PersonName);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>10ddd946db46c8fcfc0380471206a1f1</Hash>
</Codenesium>*/