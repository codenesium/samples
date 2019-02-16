using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Client
{
	public partial class ApiTransactionClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			decimal amount,
			string gatewayConfirmationNumber,
			int transactionStatusId)
		{
			this.Id = id;
			this.Amount = amount;
			this.GatewayConfirmationNumber = gatewayConfirmationNumber;
			this.TransactionStatusId = transactionStatusId;

			this.TransactionStatusIdEntity = nameof(ApiResponse.TransactionStatus);
		}

		[JsonProperty]
		public ApiTransactionStatuClientResponseModel TransactionStatusIdNavigation { get; private set; }

		public void SetTransactionStatusIdNavigation(ApiTransactionStatuClientResponseModel value)
		{
			this.TransactionStatusIdNavigation = value;
		}

		[JsonProperty]
		public decimal Amount { get; private set; }

		[JsonProperty]
		public string GatewayConfirmationNumber { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int TransactionStatusId { get; private set; }

		[JsonProperty]
		public string TransactionStatusIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>50471e732d12c193ddc620c90c8b4b0f</Hash>
</Codenesium>*/