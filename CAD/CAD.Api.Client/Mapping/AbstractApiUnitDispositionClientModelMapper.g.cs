using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public abstract class AbstractApiUnitDispositionModelMapper
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
    <Hash>8e3f041a1e2154940a5d6dac18cd21a5</Hash>
</Codenesium>*/