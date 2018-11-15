using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public abstract class AbstractApiLinkStatusModelMapper
	{
		public virtual ApiLinkStatusClientResponseModel MapClientRequestToResponse(
			int id,
			ApiLinkStatusClientRequestModel request)
		{
			var response = new ApiLinkStatusClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiLinkStatusClientRequestModel MapClientResponseToRequest(
			ApiLinkStatusClientResponseModel response)
		{
			var request = new ApiLinkStatusClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>b7364261d5dc96ff53777d1692ac69c4</Hash>
</Codenesium>*/