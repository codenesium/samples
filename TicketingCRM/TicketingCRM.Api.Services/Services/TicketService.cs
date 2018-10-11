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
			IDALTicketMapper dalticketMapper)
			: base(logger,
			       ticketRepository,
			       ticketModelValidator,
			       bolticketMapper,
			       dalticketMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>333742089cd71ac285141fa33c779745</Hash>
</Codenesium>*/