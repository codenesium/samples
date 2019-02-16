using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Services
{
	public partial class ApiSaleTicketServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiSaleTicketServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int saleId,
			int ticketId)
		{
			this.SaleId = saleId;
			this.TicketId = ticketId;
		}

		[Required]
		[JsonProperty]
		public int SaleId { get; private set; }

		[Required]
		[JsonProperty]
		public int TicketId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a631a4f5a131d1b7d9111548b248536c</Hash>
</Codenesium>*/