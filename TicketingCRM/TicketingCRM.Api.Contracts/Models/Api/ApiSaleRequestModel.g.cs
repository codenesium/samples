using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
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
		public DateTime SaleDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public int TransactionId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c82609804e642f621a2735de3c2828e6</Hash>
</Codenesium>*/