using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Client
{
	public class ApiPersonModelMapper : IApiPersonModelMapper
	{
		public virtual ApiPersonClientResponseModel MapClientRequestToResponse(
			int personId,
			ApiPersonClientRequestModel request)
		{
			var response = new ApiPersonClientResponseModel();
			response.SetProperties(personId,
			                       request.PersonName);
			return response;
		}

		public virtual ApiPersonClientRequestModel MapClientResponseToRequest(
			ApiPersonClientResponseModel response)
		{
			var request = new ApiPersonClientRequestModel();
			request.SetProperties(
				response.PersonName);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>38c6a0316abd79544140f165ce943f56</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/