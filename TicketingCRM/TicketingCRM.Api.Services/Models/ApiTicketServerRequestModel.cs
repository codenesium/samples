using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Services
{
	public partial class ApiTicketServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiTicketServerRequestModel()
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
    <Hash>a3c6444781519404251335f1afdb029c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/