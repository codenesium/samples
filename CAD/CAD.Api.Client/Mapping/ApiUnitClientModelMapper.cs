using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public class ApiUnitModelMapper : IApiUnitModelMapper
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
    <Hash>c0a9faeefd4857508e641b49f3ef4280</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/