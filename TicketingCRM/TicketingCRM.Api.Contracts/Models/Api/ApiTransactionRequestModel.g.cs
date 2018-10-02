using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
	public partial class ApiTransactionRequestModel : AbstractApiRequestModel
	{
		public ApiTransactionRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			decimal amount,
			string gatewayConfirmationNumber,
			int transactionStatusId)
		{
			this.Amount = amount;
			this.GatewayConfirmationNumber = gatewayConfirmationNumber;
			this.TransactionStatusId = transactionStatusId;
		}

		[Required]
		[JsonProperty]
		public decimal Amount { get; private set; }

		[Required]
		[JsonProperty]
		public string GatewayConfirmationNumber { get; private set; }

		[Required]
		[JsonProperty]
		public int TransactionStatusId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>d0d8143a2fbe6c1a37829623ce48ec40</Hash>
</Codenesium>*/