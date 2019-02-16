using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Client
{
	public partial class ApiSaleTicketClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiSaleTicketClientRequestModel()
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
    <Hash>3d442b52f9245138eaf5f636e6cc8d82</Hash>
</Codenesium>*/