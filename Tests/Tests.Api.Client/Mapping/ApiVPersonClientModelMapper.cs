using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Client
{
	public class ApiVPersonModelMapper : IApiVPersonModelMapper
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
    <Hash>e25fd3d0ff293129cec35f24fb4099fa</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/