using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Services
{
	public partial class ApiSaleServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiSaleServerRequestModel()
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

		[Required]
		[JsonProperty]
		public string IpAddress { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Notes { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public DateTime SaleDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public int TransactionId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9f9d9c6f12bf3cf9214821acaf9bca23</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/