using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiWorkOrderServerModelMapper
	{
		public virtual ApiWorkOrderServerResponseModel MapServerRequestToResponse(
			int workOrderID,
			ApiWorkOrderServerRequestModel request)
		{
			var response = new ApiWorkOrderServerResponseModel();
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

		public virtual ApiWorkOrderServerRequestModel MapServerResponseToRequest(
			ApiWorkOrderServerResponseModel response)
		{
			var request = new ApiWorkOrderServerRequestModel();
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

		public virtual ApiWorkOrderClientRequestModel MapServerResponseToClientRequest(
			ApiWorkOrderServerResponseModel response)
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

		public JsonPatchDocument<ApiWorkOrderServerRequestModel> CreatePatch(ApiWorkOrderServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiWorkOrderServerRequestModel>();
			patch.Replace(x => x.DueDate, model.DueDate);
			patch.Replace(x => x.EndDate, model.EndDate);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.OrderQty, model.OrderQty);
			patch.Replace(x => x.ProductID, model.ProductID);
			patch.Replace(x => x.ScrappedQty, model.ScrappedQty);
			patch.Replace(x => x.ScrapReasonID, model.ScrapReasonID);
			patch.Replace(x => x.StartDate, model.StartDate);
			patch.Replace(x => x.StockedQty, model.StockedQty);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>3866b6f6b37f40b12668b66476c9f489</Hash>
</Codenesium>*/