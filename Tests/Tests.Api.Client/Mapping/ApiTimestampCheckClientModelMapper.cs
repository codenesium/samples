using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Client
{
	public class ApiTimestampCheckModelMapper : IApiTimestampCheckModelMapper
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
    <Hash>0267c358ae41768a6f65eebb7e355253</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/