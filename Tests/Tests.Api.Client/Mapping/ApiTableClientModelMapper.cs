using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Client
{
	public class ApiTableModelMapper : IApiTableModelMapper
	{
		public virtual ApiTableClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTableClientRequestModel request)
		{
			var response = new ApiTableClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiTableClientRequestModel MapClientResponseToRequest(
			ApiTableClientResponseModel response)
		{
			var request = new ApiTableClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>5fe94985f92b4a02c2c69df8e4a7ef70</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/