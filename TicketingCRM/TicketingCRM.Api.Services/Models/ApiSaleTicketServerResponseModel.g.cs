using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Services
{
	public partial class ApiSaleTicketServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			int saleId,
			int ticketId)
		{
			this.Id = id;
			this.SaleId = saleId;
			this.TicketId = ticketId;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int SaleId { get; private set; }

		[JsonProperty]
		public string SaleIdEntity { get; private set; } = RouteConstants.Sales;

		[JsonProperty]
		public ApiSaleServerResponseModel SaleIdNavigation { get; private set; }

		public void SetSaleIdNavigation(ApiSaleServerResponseModel value)
		{
			this.SaleIdNavigation = value;
		}

		[JsonProperty]
		public int TicketId { get; private set; }

		[JsonProperty]
		public string TicketIdEntity { get; private set; } = RouteConstants.Tickets;

		[JsonProperty]
		public ApiTicketServerResponseModel TicketIdNavigation { get; private set; }

		public void SetTicketIdNavigation(ApiTicketServerResponseModel value)
		{
			this.TicketIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>9a23b5e759eb5a0ba8fcf636275884c7</Hash>
</Codenesium>*/