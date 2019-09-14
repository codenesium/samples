using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Client
{
	public partial class ApiTicketClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			string publicId,
			int ticketStatusId)
		{
			this.Id = id;
			this.PublicId = publicId;
			this.TicketStatusId = ticketStatusId;

			this.TicketStatusIdEntity = nameof(ApiResponse.TicketStatus);
		}

		[JsonProperty]
		public ApiTicketStatusClientResponseModel TicketStatusIdNavigation { get; private set; }

		public void SetTicketStatusIdNavigation(ApiTicketStatusClientResponseModel value)
		{
			this.TicketStatusIdNavigation = value;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string PublicId { get; private set; }

		[JsonProperty]
		public int TicketStatusId { get; private set; }

		[JsonProperty]
		public string TicketStatusIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>effc075b44333288c899422f93b6e72a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/