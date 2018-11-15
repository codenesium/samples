using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiTransactionHistoryArchiveServerModelMapper
	{
		public virtual ApiTransactionHistoryArchiveServerResponseModel MapServerRequestToResponse(
			int transactionID,
			ApiTransactionHistoryArchiveServerRequestModel request)
		{
			var response = new ApiTransactionHistoryArchiveServerResponseModel();
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

		public virtual ApiTransactionHistoryArchiveServerRequestModel MapServerResponseToRequest(
			ApiTransactionHistoryArchiveServerResponseModel response)
		{
			var request = new ApiTransactionHistoryArchiveServerRequestModel();
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

		public virtual ApiTransactionHistoryArchiveClientRequestModel MapServerResponseToClientRequest(
			ApiTransactionHistoryArchiveServerResponseModel response)
		{
			var request = new ApiTransactionHistoryArchiveClientRequestModel();
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

		public JsonPatchDocument<ApiTransactionHistoryArchiveServerRequestModel> CreatePatch(ApiTransactionHistoryArchiveServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTransactionHistoryArchiveServerRequestModel>();
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
    <Hash>2e0abeef353f353d0a42fac9f3a472a7</Hash>
</Codenesium>*/