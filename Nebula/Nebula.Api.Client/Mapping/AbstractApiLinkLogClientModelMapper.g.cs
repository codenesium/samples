using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public abstract class AbstractApiLinkLogModelMapper
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
    <Hash>73e7e2b455e52a37fc0fa03605812e3f</Hash>
</Codenesium>*/