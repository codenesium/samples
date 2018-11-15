using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiSalesReasonModelMapper
	{
		public virtual ApiSalesReasonClientResponseModel MapClientRequestToResponse(
			int salesReasonID,
			ApiSalesReasonClientRequestModel request)
		{
			var response = new ApiSalesReasonClientResponseModel();
			response.SetProperties(salesReasonID,
			                       request.ModifiedDate,
			                       request.Name,
			                       request.ReasonType);
			return response;
		}

		public virtual ApiSalesReasonClientRequestModel MapClientResponseToRequest(
			ApiSalesReasonClientResponseModel response)
		{
			var request = new ApiSalesReasonClientRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name,
				response.ReasonType);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>88c6f7f7e97227ef86ef373ff77ad950</Hash>
</Codenesium>*/