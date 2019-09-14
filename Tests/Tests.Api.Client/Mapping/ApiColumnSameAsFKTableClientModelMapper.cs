using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Client
{
	public class ApiColumnSameAsFKTableModelMapper : IApiColumnSameAsFKTableModelMapper
	{
		public virtual ApiColumnSameAsFKTableClientResponseModel MapClientRequestToResponse(
			int id,
			ApiColumnSameAsFKTableClientRequestModel request)
		{
			var response = new ApiColumnSameAsFKTableClientResponseModel();
			response.SetProperties(id,
			                       request.Person,
			                       request.PersonId);
			return response;
		}

		public virtual ApiColumnSameAsFKTableClientRequestModel MapClientResponseToRequest(
			ApiColumnSameAsFKTableClientResponseModel response)
		{
			var request = new ApiColumnSameAsFKTableClientRequestModel();
			request.SetProperties(
				response.Person,
				response.PersonId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>82f69e46d4c76ca14d989e82c029c2bc</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/