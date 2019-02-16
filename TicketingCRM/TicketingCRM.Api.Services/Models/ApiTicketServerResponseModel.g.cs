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
		public ApiTicketStatuServerResponseModel TicketStatusIdNavigation { get; private set; }

		public void SetTicketStatusIdNavigation(ApiTicketStatuServerResponseModel value)
		{
			this.TicketStatusIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>61d7a68b3baa540f28a8a558cb1e68b1</Hash>
</Codenesium>*/