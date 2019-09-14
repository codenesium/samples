using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public class ApiCallPersonModelMapper : IApiCallPersonModelMapper
	{
		public virtual ApiCallPersonClientResponseModel MapClientRequestToResponse(
			int id,
			ApiCallPersonClientRequestModel request)
		{
			var response = new ApiCallPersonClientResponseModel();
			response.SetProperties(id,
			                       request.Note,
			                       request.PersonId,
			                       request.PersonTypeId);
			return response;
		}

		public virtual ApiCallPersonClientRequestModel MapClientResponseToRequest(
			ApiCallPersonClientResponseModel response)
		{
			var request = new ApiCallPersonClientRequestModel();
			request.SetProperties(
				response.Note,
				response.PersonId,
				response.PersonTypeId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>94576941286565df574ecf9e9f94822b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/