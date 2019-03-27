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
			IDALTicketMapper dalTicketMapper,
			IDALSaleTicketsMapper dalSaleTicketsMapper)
			: base(logger,
			       mediator,
			       ticketRepository,
			       ticketModelValidator,
			       dalTicketMapper,
			       dalSaleTicketsMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>cfd9f7096ff0963413799ff8f8c87a2c</Hash>
</Codenesium>*/