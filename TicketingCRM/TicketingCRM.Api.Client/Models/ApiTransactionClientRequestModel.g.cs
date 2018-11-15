using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Client
{
	public partial class ApiTransactionClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiTransactionClientRequestModel()
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
		public decimal Amount { get; private set; } = default(decimal);

		[JsonProperty]
		public string GatewayConfirmationNumber { get; private set; } = default(string);

		[JsonProperty]
		public int TransactionStatusId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>360030e1cfbb768fa42e55d324e748e5</Hash>
</Codenesium>*/