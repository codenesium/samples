using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
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
		public int TransactionStatusId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9815ff3a755b27432790b5c06d361abe</Hash>
</Codenesium>*/