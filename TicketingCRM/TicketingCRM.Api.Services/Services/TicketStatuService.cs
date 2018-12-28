using MediatR;
using Microsoft.Extensions.Logging;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class TicketStatuService : AbstractTicketStatuService, ITicketStatuService
	{
		public TicketStatuService(
			ILogger<ITicketStatuRepository> logger,
			IMediator mediator,
			ITicketStatuRepository ticketStatuRepository,
			IApiTicketStatuServerRequestModelValidator ticketStatuModelValidator,
			IBOLTicketStatuMapper bolTicketStatuMapper,
			IDALTicketStatuMapper dalTicketStatuMapper,
			IBOLTicketMapper bolTicketMapper,
			IDALTicketMapper dalTicketMapper)
			: base(logger,
			       mediator,
			       ticketStatuRepository,
			       ticketStatuModelValidator,
			       bolTicketStatuMapper,
			       dalTicketStatuMapper,
			       bolTicketMapper,
			       dalTicketMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>43b6766575db45b22ef661ae127cd5ca</Hash>
</Codenesium>*/