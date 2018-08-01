using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
	public partial class ApiSaleResponseModel : AbstractApiResponseModel
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

		[Required]
		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public string IpAddress { get; private set; }

		[Required]
		[JsonProperty]
		public string Notes { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime SaleDate { get; private set; }

		[Required]
		[JsonProperty]
		public int TransactionId { get; private set; }

		[JsonProperty]
		public string TransactionIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>6883d87753ac10bc99d31f36acbfa2e5</Hash>
</Codenesium>*/