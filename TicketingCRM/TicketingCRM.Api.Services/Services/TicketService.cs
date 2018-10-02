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
			IBOLSaleTicketMapper bolSaleTicketMapper,
			IDALSaleTicketMapper dalSaleTicketMapper
			)
			: base(logger,
			       ticketRepository,
			       ticketModelValidator,
			       bolticketMapper,
			       dalticketMapper,
			       bolSaleTicketMapper,
			       dalSaleTicketMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5f961d10b6ded0aff7ea55922ae4efdc</Hash>
</Codenesium>*/