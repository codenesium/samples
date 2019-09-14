using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Client
{
	public partial class ApiTicketClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiTicketClientRequestModel()
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
		public string PublicId { get; private set; } = default(string);

		[JsonProperty]
		public int TicketStatusId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>4c38de43a9618608305d0bbd741e558d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/