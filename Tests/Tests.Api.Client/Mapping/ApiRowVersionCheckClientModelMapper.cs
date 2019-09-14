using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Client
{
	public class ApiRowVersionCheckModelMapper : IApiRowVersionCheckModelMapper
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
    <Hash>c8415f17b55b59842bf53aa240f259cd</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/