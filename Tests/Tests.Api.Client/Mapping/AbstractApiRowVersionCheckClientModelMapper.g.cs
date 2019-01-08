using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Client
{
	public abstract class AbstractApiRowVersionCheckModelMapper
	{
		public virtual ApiRowVersionCheckClientResponseModel MapClientRequestToResponse(
			int id,
			ApiRowVersionCheckClientRequestModel request)
		{
			var response = new ApiRowVersionCheckClientResponseModel();
			response.SetProperties(id,
			                       request.Name,
			                       request.RowVersion);
			return response;
		}

		public virtual ApiRowVersionCheckClientRequestModel MapClientResponseToRequest(
			ApiRowVersionCheckClientResponseModel response)
		{
			var request = new ApiRowVersionCheckClientRequestModel();
			request.SetProperties(
				response.Name,
				response.RowVersion);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>1344abcfca30954ddb70f6e7b28e4808</Hash>
</Codenesium>*/