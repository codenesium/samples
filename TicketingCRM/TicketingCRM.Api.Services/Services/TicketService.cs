using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class TicketService : AbstractTicketService, ITicketService
	{
		public TicketService(
			ILogger<ITicketRepository> logger,
			ITicketRepository ticketRepository,
			IApiTicketRequestModelValidator ticketModelValidator,
			IBOLTicketMapper bolticketMapper,
			IDALTicketMapper dalticketMapper,
			IBOLSaleTicketsMapper bolSaleTicketsMapper,
			IDALSaleTicketsMapper dalSaleTicketsMapper
			)
			: base(logger,
			       ticketRepository,
			       ticketModelValidator,
			       bolticketMapper,
			       dalticketMapper,
			       bolSaleTicketsMapper,
			       dalSaleTicketsMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>064b86732d1d0aacdcba35fd9f6f911b</Hash>
</Codenesium>*/