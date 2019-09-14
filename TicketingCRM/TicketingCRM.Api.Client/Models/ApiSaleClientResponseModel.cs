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
			string notes,
			DateTime saleDate,
			int transactionId)
		{
			this.Id = id;
			this.IpAddress = ipAddress;
			this.Notes = notes;
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
		public string Notes { get; private set; }

		[JsonProperty]
		public DateTime SaleDate { get; private set; }

		[JsonProperty]
		public int TransactionId { get; private set; }

		[JsonProperty]
		public string TransactionIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>2eec0a01d448e9fd32bc6ef78ab445e4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/