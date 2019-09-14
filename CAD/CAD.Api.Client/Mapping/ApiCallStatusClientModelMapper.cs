using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public class ApiCallStatusModelMapper : IApiCallStatusModelMapper
	{
		public virtual ApiCallStatusClientResponseModel MapClientRequestToResponse(
			int id,
			ApiCallStatusClientRequestModel request)
		{
			var response = new ApiCallStatusClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiCallStatusClientRequestModel MapClientResponseToRequest(
			ApiCallStatusClientResponseModel response)
		{
			var request = new ApiCallStatusClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>67cc141516df95aae9f583c3f1433a6d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/