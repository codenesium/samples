using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiIllustrationModelMapper
	{
		public virtual ApiIllustrationClientResponseModel MapClientRequestToResponse(
			int illustrationID,
			ApiIllustrationClientRequestModel request)
		{
			var response = new ApiIllustrationClientResponseModel();
			response.SetProperties(illustrationID,
			                       request.Diagram,
			                       request.ModifiedDate);
			return response;
		}

		public virtual ApiIllustrationClientRequestModel MapClientResponseToRequest(
			ApiIllustrationClientResponseModel response)
		{
			var request = new ApiIllustrationClientRequestModel();
			request.SetProperties(
				response.Diagram,
				response.ModifiedDate);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>1c369c4f4179cbcce7f03f11bedce09d</Hash>
</Codenesium>*/