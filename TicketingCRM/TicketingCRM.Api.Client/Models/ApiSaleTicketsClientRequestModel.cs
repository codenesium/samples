using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Client
{
	public partial class ApiSaleTicketsClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiSaleTicketsClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int saleId,
			int ticketId)
		{
			this.SaleId = saleId;
			this.TicketId = ticketId;
		}

		[JsonProperty]
		public int SaleId { get; private set; }

		[JsonProperty]
		public int TicketId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7322cd8b69852e8d28d7877543bc01e0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/