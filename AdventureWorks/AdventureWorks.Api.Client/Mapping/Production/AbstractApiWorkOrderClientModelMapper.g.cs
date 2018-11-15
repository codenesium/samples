using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiWorkOrderModelMapper
	{
		public virtual ApiWorkOrderClientResponseModel MapClientRequestToResponse(
			int workOrderID,
			ApiWorkOrderClientRequestModel request)
		{
			var response = new ApiWorkOrderClientResponseModel();
			response.SetProperties(workOrderID,
			                       request.DueDate,
			                       request.EndDate,
			                       request.ModifiedDate,
			                       request.OrderQty,
			                       request.ProductID,
			                       request.ScrappedQty,
			                       request.ScrapReasonID,
			                       request.StartDate,
			                       request.StockedQty);
			return response;
		}

		public virtual ApiWorkOrderClientRequestModel MapClientResponseToRequest(
			ApiWorkOrderClientResponseModel response)
		{
			var request = new ApiWorkOrderClientRequestModel();
			request.SetProperties(
				response.DueDate,
				response.EndDate,
				response.ModifiedDate,
				response.OrderQty,
				response.ProductID,
				response.ScrappedQty,
				response.ScrapReasonID,
				response.StartDate,
				response.StockedQty);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>30eccf3ebee498d00edc3f3e83e14172</Hash>
</Codenesium>*/