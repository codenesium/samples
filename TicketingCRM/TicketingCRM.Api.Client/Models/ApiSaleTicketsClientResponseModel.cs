using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Client
{
	public partial class ApiSaleTicketsClientResponseModel : AbstractApiClientResponseModel
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
    <Hash>09471655dbd8cbdcb0f808fdf71b3012</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/