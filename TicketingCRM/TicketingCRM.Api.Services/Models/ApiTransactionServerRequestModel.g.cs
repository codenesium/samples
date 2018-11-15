using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Services
{
	public partial class ApiTransactionServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiTransactionServerRequestModel()
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
    <Hash>d64c8a06dc72c49aec6c7568bbd2d9e9</Hash>
</Codenesium>*/