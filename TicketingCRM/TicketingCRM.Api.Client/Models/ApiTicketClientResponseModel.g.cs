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
    <Hash>b328041b0d1e3babf0090f49c7844907</Hash>
</Codenesium>*/