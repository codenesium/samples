using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public abstract class AbstractApiCallDispositionModelMapper
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
    <Hash>9fb339f05557c05d459885b6d8e85199</Hash>
</Codenesium>*/