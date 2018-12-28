using MediatR;
using Microsoft.Extensions.Logging;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class TicketService : AbstractTicketService, ITicketService
	{
		public TicketService(
			ILogger<ITicketRepository> logger,
			IMediator mediator,
			ITicketRepository ticketRepository,
			IApiTicketServerRequestModelValidator ticketModelValidator,
			IBOLTicketMapper bolTicketMapper,
			IDALTicketMapper dalTicketMapper)
			: base(logger,
			       mediator,
			       ticketRepository,
			       ticketModelValidator,
			       bolTicketMapper,
			       dalTicketMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>cf3afaabaf0db0aa523f14e2bcec34c8</Hash>
</Codenesium>*/