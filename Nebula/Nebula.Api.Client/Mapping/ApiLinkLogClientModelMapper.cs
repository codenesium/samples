using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public class ApiLinkLogModelMapper : IApiLinkLogModelMapper
	{
		public virtual ApiLinkLogClientResponseModel MapClientRequestToResponse(
			int id,
			ApiLinkLogClientRequestModel request)
		{
			var response = new ApiLinkLogClientResponseModel();
			response.SetProperties(id,
			                       request.DateEntered,
			                       request.LinkId,
			                       request.Log);
			return response;
		}

		public virtual ApiLinkLogClientRequestModel MapClientResponseToRequest(
			ApiLinkLogClientResponseModel response)
		{
			var request = new ApiLinkLogClientRequestModel();
			request.SetProperties(
				response.DateEntered,
				response.LinkId,
				response.Log);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>189f5ef1135951bf8345eca74700381a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/