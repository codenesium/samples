using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Services
{
	public partial class ApiTicketServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			string publicId,
			int ticketStatusId)
		{
			this.Id = id;
			this.PublicId = publicId;
			this.TicketStatusId = ticketStatusId;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string PublicId { get; private set; }

		[JsonProperty]
		public int TicketStatusId { get; private set; }

		[JsonProperty]
		public string TicketStatusIdEntity { get; private set; } = RouteConstants.TicketStatus;

		[JsonProperty]
		public ApiTicketStatusServerResponseModel TicketStatusIdNavigation { get; private set; }

		public void SetTicketStatusIdNavigation(ApiTicketStatusServerResponseModel value)
		{
			this.TicketStatusIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>3ba6272e31e7d42f9b52024b69a1ec8b</Hash>
</Codenesium>*/