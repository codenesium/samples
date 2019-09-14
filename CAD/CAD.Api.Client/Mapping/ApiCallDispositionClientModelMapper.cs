using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public class ApiCallDispositionModelMapper : IApiCallDispositionModelMapper
	{
		public virtual ApiCallDispositionClientResponseModel MapClientRequestToResponse(
			int id,
			ApiCallDispositionClientRequestModel request)
		{
			var response = new ApiCallDispositionClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiCallDispositionClientRequestModel MapClientResponseToRequest(
			ApiCallDispositionClientResponseModel response)
		{
			var request = new ApiCallDispositionClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>8a9488a83958343be725b0083e684e22</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/