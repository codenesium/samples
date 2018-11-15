using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Client
{
	public abstract class AbstractApiTimestampCheckModelMapper
	{
		public virtual ApiTimestampCheckClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTimestampCheckClientRequestModel request)
		{
			var response = new ApiTimestampCheckClientResponseModel();
			response.SetProperties(id,
			                       request.Name,
			                       request.Timestamp);
			return response;
		}

		public virtual ApiTimestampCheckClientRequestModel MapClientResponseToRequest(
			ApiTimestampCheckClientResponseModel response)
		{
			var request = new ApiTimestampCheckClientRequestModel();
			request.SetProperties(
				response.Name,
				response.Timestamp);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>73b0b1ee3611d7ce3dc2f18299920d3f</Hash>
</Codenesium>*/