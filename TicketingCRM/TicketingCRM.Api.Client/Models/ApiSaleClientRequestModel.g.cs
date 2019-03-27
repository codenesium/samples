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
			string notes,
			DateTime saleDate,
			int transactionId)
		{
			this.IpAddress = ipAddress;
			this.Notes = notes;
			this.SaleDate = saleDate;
			this.TransactionId = transactionId;
		}

		[JsonProperty]
		public string IpAddress { get; private set; } = default(string);

		[JsonProperty]
		public string Notes { get; private set; } = default(string);

		[JsonProperty]
		public DateTime SaleDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public int TransactionId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>07ff86435493139102a627c9b24782e2</Hash>
</Codenesium>*/