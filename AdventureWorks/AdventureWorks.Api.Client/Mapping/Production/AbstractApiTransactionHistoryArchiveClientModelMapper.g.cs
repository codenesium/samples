using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiTransactionHistoryArchiveModelMapper
	{
		public virtual ApiTransactionHistoryArchiveClientResponseModel MapClientRequestToResponse(
			int transactionID,
			ApiTransactionHistoryArchiveClientRequestModel request)
		{
			var response = new ApiTransactionHistoryArchiveClientResponseModel();
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

		public virtual ApiTransactionHistoryArchiveClientRequestModel MapClientResponseToRequest(
			ApiTransactionHistoryArchiveClientResponseModel response)
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
	}
}

/*<Codenesium>
    <Hash>accc58a360b9fd059498b544ba404a5b</Hash>
</Codenesium>*/