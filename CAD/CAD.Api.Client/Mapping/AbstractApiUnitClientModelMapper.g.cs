using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public abstract class AbstractApiUnitModelMapper
	{
		public virtual ApiUnitClientResponseModel MapClientRequestToResponse(
			int id,
			ApiUnitClientRequestModel request)
		{
			var response = new ApiUnitClientResponseModel();
			response.SetProperties(id,
			                       request.CallSign);
			return response;
		}

		public virtual ApiUnitClientRequestModel MapClientResponseToRequest(
			ApiUnitClientResponseModel response)
		{
			var request = new ApiUnitClientRequestModel();
			request.SetProperties(
				response.CallSign);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>ed4afda94ad0da94f71807106103ce70</Hash>
</Codenesium>*/