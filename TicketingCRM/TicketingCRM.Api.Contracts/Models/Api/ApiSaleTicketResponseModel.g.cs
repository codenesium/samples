using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
	public partial class ApiSaleTicketResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			int saleId,
			int ticketId)
		{
			this.Id = id;
			this.SaleId = saleId;
			this.TicketId = ticketId;

			this.SaleIdEntity = nameof(ApiResponse.Sales);
			this.TicketIdEntity = nameof(ApiResponse.Tickets);
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int SaleId { get; private set; }

		[JsonProperty]
		public string SaleIdEntity { get; set; }

		[JsonProperty]
		public int TicketId { get; private set; }

		[JsonProperty]
		public string TicketIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>872c3f16b9666ed57a9bbe3c1d658624</Hash>
</Codenesium>*/