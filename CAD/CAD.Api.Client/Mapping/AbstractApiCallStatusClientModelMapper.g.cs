using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public abstract class AbstractApiCallStatusModelMapper
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
    <Hash>573d429fb6496e3e925668bd83b52e51</Hash>
</Codenesium>*/