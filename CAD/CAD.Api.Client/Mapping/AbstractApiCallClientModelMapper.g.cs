using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public abstract class AbstractApiCallModelMapper
	{
		public virtual ApiCallClientResponseModel MapClientRequestToResponse(
			int id,
			ApiCallClientRequestModel request)
		{
			var response = new ApiCallClientResponseModel();
			response.SetProperties(id,
			                       request.AddressId,
			                       request.CallDispositionId,
			                       request.CallStatusId,
			                       request.CallString,
			                       request.CallTypeId,
			                       request.DateCleared,
			                       request.DateCreated,
			                       request.DateDispatched,
			                       request.QuickCallNumber);
			return response;
		}

		public virtual ApiCallClientRequestModel MapClientResponseToRequest(
			ApiCallClientResponseModel response)
		{
			var request = new ApiCallClientRequestModel();
			request.SetProperties(
				response.AddressId,
				response.CallDispositionId,
				response.CallStatusId,
				response.CallString,
				response.CallTypeId,
				response.DateCleared,
				response.DateCreated,
				response.DateDispatched,
				response.QuickCallNumber);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>7321134c850a2d9432c8ac412209f02f</Hash>
</Codenesium>*/