using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Services
{
	public partial class ApiTransactionServerResponseModel : AbstractApiServerResponseModel
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
		public string TransactionStatusIdEntity { get; private set; } = RouteConstants.TransactionStatus;

		[JsonProperty]
		public ApiTransactionStatuServerResponseModel TransactionStatusIdNavigation { get; private set; }

		public void SetTransactionStatusIdNavigation(ApiTransactionStatuServerResponseModel value)
		{
			this.TransactionStatusIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>4af57d77f1f2b9a113ce91e8a31569f2</Hash>
</Codenesium>*/