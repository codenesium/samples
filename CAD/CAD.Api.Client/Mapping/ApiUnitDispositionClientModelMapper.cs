using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public class ApiUnitDispositionModelMapper : IApiUnitDispositionModelMapper
	{
		public virtual ApiUnitDispositionClientResponseModel MapClientRequestToResponse(
			int id,
			ApiUnitDispositionClientRequestModel request)
		{
			var response = new ApiUnitDispositionClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiUnitDispositionClientRequestModel MapClientResponseToRequest(
			ApiUnitDispositionClientResponseModel response)
		{
			var request = new ApiUnitDispositionClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>ea73a357b585db8384a9314a6cd939b0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/