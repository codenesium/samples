using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public class ApiClaspModelMapper : IApiClaspModelMapper
	{
		public virtual ApiClaspClientResponseModel MapClientRequestToResponse(
			int id,
			ApiClaspClientRequestModel request)
		{
			var response = new ApiClaspClientResponseModel();
			response.SetProperties(id,
			                       request.NextChainId,
			                       request.PreviousChainId);
			return response;
		}

		public virtual ApiClaspClientRequestModel MapClientResponseToRequest(
			ApiClaspClientResponseModel response)
		{
			var request = new ApiClaspClientRequestModel();
			request.SetProperties(
				response.NextChainId,
				response.PreviousChainId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>23b586389f6483c70cd0fd5c2b9232e0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/