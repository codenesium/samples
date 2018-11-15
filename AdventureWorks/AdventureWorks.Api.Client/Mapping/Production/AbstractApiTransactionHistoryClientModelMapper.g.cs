using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiTransactionHistoryModelMapper
	{
		public virtual ApiTransactionHistoryClientResponseModel MapClientRequestToResponse(
			int transactionID,
			ApiTransactionHistoryClientRequestModel request)
		{
			var response = new ApiTransactionHistoryClientResponseModel();
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

		public virtual ApiTransactionHistoryClientRequestModel MapClientResponseToRequest(
			ApiTransactionHistoryClientResponseModel response)
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
	}
}

/*<Codenesium>
    <Hash>2298fb67557519dbba94c7249910a736</Hash>
</Codenesium>*/