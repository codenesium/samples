using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Client
{
	public partial class ApiSaleTicketClientResponseModel : AbstractApiClientResponseModel
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
		public ApiSaleClientResponseModel SaleIdNavigation { get; private set; }

		public void SetSaleIdNavigation(ApiSaleClientResponseModel value)
		{
			this.SaleIdNavigation = value;
		}

		[JsonProperty]
		public ApiTicketClientResponseModel TicketIdNavigation { get; private set; }

		public void SetTicketIdNavigation(ApiTicketClientResponseModel value)
		{
			this.TicketIdNavigation = value;
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
    <Hash>0fb8c6650839aa7adb2ebba695fee2df</Hash>
</Codenesium>*/