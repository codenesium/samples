using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Services
{
	public partial class ApiSaleTicketsServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiSaleTicketsServerRequestModel()
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

		[Required]
		[JsonProperty]
		public int SaleId { get; private set; }

		[Required]
		[JsonProperty]
		public int TicketId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>eedaeb064a6c1d18121c5e5579cd7e5f</Hash>
</Codenesium>*/