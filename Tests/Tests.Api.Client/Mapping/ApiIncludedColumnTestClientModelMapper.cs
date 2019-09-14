using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Client
{
	public class ApiIncludedColumnTestModelMapper : IApiIncludedColumnTestModelMapper
	{
		public virtual ApiIncludedColumnTestClientResponseModel MapClientRequestToResponse(
			int id,
			ApiIncludedColumnTestClientRequestModel request)
		{
			var response = new ApiIncludedColumnTestClientResponseModel();
			response.SetProperties(id,
			                       request.Name,
			                       request.Name2);
			return response;
		}

		public virtual ApiIncludedColumnTestClientRequestModel MapClientResponseToRequest(
			ApiIncludedColumnTestClientResponseModel response)
		{
			var request = new ApiIncludedColumnTestClientRequestModel();
			request.SetProperties(
				response.Name,
				response.Name2);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>fb6bf9d7490391ae6bf6ac742a77d591</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/