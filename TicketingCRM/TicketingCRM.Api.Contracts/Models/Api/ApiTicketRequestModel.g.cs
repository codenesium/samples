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

		[Required]
		[JsonProperty]
		public string PublicId { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int TicketStatusId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>b803c3226d34bb81737b508bb3d186e7</Hash>
</Codenesium>*/