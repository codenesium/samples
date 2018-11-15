using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Client
{
	public abstract class AbstractApiPersonRefModelMapper
	{
		public virtual ApiPersonRefClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPersonRefClientRequestModel request)
		{
			var response = new ApiPersonRefClientResponseModel();
			response.SetProperties(id,
			                       request.PersonAId,
			                       request.PersonBId);
			return response;
		}

		public virtual ApiPersonRefClientRequestModel MapClientResponseToRequest(
			ApiPersonRefClientResponseModel response)
		{
			var request = new ApiPersonRefClientRequestModel();
			request.SetProperties(
				response.PersonAId,
				response.PersonBId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>95f12d18770c39e68c1aa22ceecabfae</Hash>
</Codenesium>*/