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
		public string TicketStatusIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>313226adab76ea19c48b6139e223645c</Hash>
</Codenesium>*/