using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
	public partial class ApiSaleRequestModel : AbstractApiRequestModel
	{
		public ApiSaleRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string ipAddress,
			string note,
			DateTime saleDate,
			int transactionId)
		{
			this.IpAddress = ipAddress;
			this.Note = note;
			this.SaleDate = saleDate;
			this.TransactionId = transactionId;
		}

		[Required]
		[JsonProperty]
		public string IpAddress { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Note { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public DateTime SaleDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public int TransactionId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>7637faa77588c984b48e5ab8ccf87693</Hash>
</Codenesium>*/