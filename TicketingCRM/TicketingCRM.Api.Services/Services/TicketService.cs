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
			IDALSaleTicketMapper dalSaleTicketMapper)
			: base(logger,
			       mediator,
			       ticketRepository,
			       ticketModelValidator,
			       dalTicketMapper,
			       dalSaleTicketMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d5a1a73bb98e5d00ce846388acfce2d8</Hash>
</Codenesium>*/