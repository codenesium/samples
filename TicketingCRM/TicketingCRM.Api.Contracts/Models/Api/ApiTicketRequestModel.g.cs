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
    <Hash>916e5e238fa98be2b3ce08d8eac4b49c</Hash>
</Codenesium>*/