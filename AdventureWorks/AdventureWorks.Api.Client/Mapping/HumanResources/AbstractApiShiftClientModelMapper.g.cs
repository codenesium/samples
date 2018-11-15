using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiShiftModelMapper
	{
		public virtual ApiShiftClientResponseModel MapClientRequestToResponse(
			int shiftID,
			ApiShiftClientRequestModel request)
		{
			var response = new ApiShiftClientResponseModel();
			response.SetProperties(shiftID,
			                       request.EndTime,
			                       request.ModifiedDate,
			                       request.Name,
			                       request.StartTime);
			return response;
		}

		public virtual ApiShiftClientRequestModel MapClientResponseToRequest(
			ApiShiftClientResponseModel response)
		{
			var request = new ApiShiftClientRequestModel();
			request.SetProperties(
				response.EndTime,
				response.ModifiedDate,
				response.Name,
				response.StartTime);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>ed61c4281ae886f3b40e801cbcc933d8</Hash>
</Codenesium>*/