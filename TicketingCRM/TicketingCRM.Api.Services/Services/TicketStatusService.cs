using MediatR;
using Microsoft.Extensions.Logging;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class TicketStatusService : AbstractTicketStatusService, ITicketStatusService
	{
		public TicketStatusService(
			ILogger<ITicketStatusRepository> logger,
			IMediator mediator,
			ITicketStatusRepository ticketStatusRepository,
			IApiTicketStatusServerRequestModelValidator ticketStatusModelValidator,
			IDALTicketStatusMapper dalTicketStatusMapper,
			IDALTicketMapper dalTicketMapper)
			: base(logger,
			       mediator,
			       ticketStatusRepository,
			       ticketStatusModelValidator,
			       dalTicketStatusMapper,
			       dalTicketMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>0986a70a8fb925c38b6553aa2b470381</Hash>
</Codenesium>*/