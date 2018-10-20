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
		public decimal Amount { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public string GatewayConfirmationNumber { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int TransactionStatusId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>bfb1216e90ea7cbde8b5e2fa7bcb9609</Hash>
</Codenesium>*/