using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiTransactionHistoryModelMapper
	{
		public virtual ApiTransactionHistoryResponseModel MapRequestToResponse(
			int transactionID,
			ApiTransactionHistoryRequestModel request)
		{
			var response = new ApiTransactionHistoryResponseModel();
			response.SetProperties(transactionID,
			                       request.ActualCost,
			                       request.ModifiedDate,
			                       request.ProductID,
			                       request.Quantity,
			                       request.ReferenceOrderID,
			                       request.ReferenceOrderLineID,
			                       request.TransactionDate,
			                       request.TransactionType);
			return response;
		}

		public virtual ApiTransactionHistoryRequestModel MapResponseToRequest(
			ApiTransactionHistoryResponseModel response)
		{
			var request = new ApiTransactionHistoryRequestModel();
			request.SetProperties(
				response.ActualCost,
				response.ModifiedDate,
				response.ProductID,
				response.Quantity,
				response.ReferenceOrderID,
				response.ReferenceOrderLineID,
				response.TransactionDate,
				response.TransactionType);
			return request;
		}

		public JsonPatchDocument<ApiTransactionHistoryRequestModel> CreatePatch(ApiTransactionHistoryRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTransactionHistoryRequestModel>();
			patch.Replace(x => x.ActualCost, model.ActualCost);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.ProductID, model.ProductID);
			patch.Replace(x => x.Quantity, model.Quantity);
			patch.Replace(x => x.ReferenceOrderID, model.ReferenceOrderID);
			patch.Replace(x => x.ReferenceOrderLineID, model.ReferenceOrderLineID);
			patch.Replace(x => x.TransactionDate, model.TransactionDate);
			patch.Replace(x => x.TransactionType, model.TransactionType);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>582904e863d55ff9c421c7fe9b7bb551</Hash>
</Codenesium>*/