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

		[JsonProperty]
		public decimal Amount { get; private set; }

		[JsonProperty]
		public string GatewayConfirmationNumber { get; private set; }

		[JsonProperty]
		public int TransactionStatusId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0bfd2f1b01b577b49d410c296a5dfe22</Hash>
</Codenesium>*/