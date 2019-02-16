using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Client
{
	public partial class ApiSaleClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			string ipAddress,
			string note,
			DateTime saleDate,
			int transactionId)
		{
			this.Id = id;
			this.IpAddress = ipAddress;
			this.Note = note;
			this.SaleDate = saleDate;
			this.TransactionId = transactionId;

			this.TransactionIdEntity = nameof(ApiResponse.Transactions);
		}

		[JsonProperty]
		public ApiTransactionClientResponseModel TransactionIdNavigation { get; private set; }

		public void SetTransactionIdNavigation(ApiTransactionClientResponseModel value)
		{
			this.TransactionIdNavigation = value;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string IpAddress { get; private set; }

		[JsonProperty]
		public string Note { get; private set; }

		[JsonProperty]
		public DateTime SaleDate { get; private set; }

		[JsonProperty]
		public int TransactionId { get; private set; }

		[JsonProperty]
		public string TransactionIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>8ff0bb3f671e248ac9932134d6cb6a54</Hash>
</Codenesium>*/