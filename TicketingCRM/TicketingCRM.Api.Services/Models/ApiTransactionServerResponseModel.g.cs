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
		public string TransactionStatusIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>2faf2afdc0494989e61150eab5442a6d</Hash>
</Codenesium>*/