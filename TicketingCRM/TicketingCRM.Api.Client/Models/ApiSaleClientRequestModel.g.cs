using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Client
{
	public partial class ApiSaleClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiSaleClientRequestModel()
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

		[JsonProperty]
		public string IpAddress { get; private set; } = default(string);

		[JsonProperty]
		public string Note { get; private set; } = default(string);

		[JsonProperty]
		public DateTime SaleDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public int TransactionId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>2a623d374ddcbd4650a0013fc0e12bef</Hash>
</Codenesium>*/