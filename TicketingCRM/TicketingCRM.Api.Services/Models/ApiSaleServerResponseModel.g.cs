using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Services
{
	public partial class ApiSaleServerResponseModel : AbstractApiServerResponseModel
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
		public string TransactionIdEntity { get; private set; } = RouteConstants.Transactions;

		[JsonProperty]
		public ApiTransactionServerResponseModel TransactionIdNavigation { get; private set; }

		public void SetTransactionIdNavigation(ApiTransactionServerResponseModel value)
		{
			this.TransactionIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>8fdd2da180756e1e879059cabbd831f6</Hash>
</Codenesium>*/