using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiScrapReasonModelMapper
	{
		public virtual ApiScrapReasonClientResponseModel MapClientRequestToResponse(
			short scrapReasonID,
			ApiScrapReasonClientRequestModel request)
		{
			var response = new ApiScrapReasonClientResponseModel();
			response.SetProperties(scrapReasonID,
			                       request.ModifiedDate,
			                       request.Name);
			return response;
		}

		public virtual ApiScrapReasonClientRequestModel MapClientResponseToRequest(
			ApiScrapReasonClientResponseModel response)
		{
			var request = new ApiScrapReasonClientRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>532169f9271da7d44f202ab264c7e6f4</Hash>
</Codenesium>*/