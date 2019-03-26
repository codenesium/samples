using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiTransactionHistoryServerModelMapper
	{
		public virtual ApiTransactionHistoryServerResponseModel MapServerRequestToResponse(
			int transactionID,
			ApiTransactionHistoryServerRequestModel request)
		{
			var response = new ApiTransactionHistoryServerResponseModel();
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

		public virtual ApiTransactionHistoryServerRequestModel MapServerResponseToRequest(
			ApiTransactionHistoryServerResponseModel response)
		{
			var request = new ApiTransactionHistoryServerRequestModel();
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

		public virtual ApiTransactionHistoryClientRequestModel MapServerResponseToClientRequest(
			ApiTransactionHistoryServerResponseModel response)
		{
			var request = new ApiTransactionHistoryClientRequestModel();
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

		public JsonPatchDocument<ApiTransactionHistoryServerRequestModel> CreatePatch(ApiTransactionHistoryServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTransactionHistoryServerRequestModel>();
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
    <Hash>37ea5966498da1532ec788259ca62c94</Hash>
</Codenesium>*/