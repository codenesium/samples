using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

		[JsonProperty]
		public string PublicId { get; private set; }

		[JsonProperty]
		public int TicketStatusId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>667a29269729654d092be3cec0cea95b</Hash>
</Codenesium>*/