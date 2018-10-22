using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
	public partial class ApiTicketRequestModel : AbstractApiRequestModel
	{
		public ApiTicketRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string publicId,
			int ticketStatusId)
		{
			this.PublicId = publicId;
			this.TicketStatusId = ticketStatusId;
		}

		[Required]
		[JsonProperty]
		public string PublicId { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int TicketStatusId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5486b011ac134d6f939311a05b838916</Hash>
</Codenesium>*/