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
			IDALTicketStatuMapper dalTicketStatuMapper,
			IDALTicketMapper dalTicketMapper)
			: base(logger,
			       mediator,
			       ticketStatuRepository,
			       ticketStatuModelValidator,
			       dalTicketStatuMapper,
			       dalTicketMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5b8a85360c2ac6912042e0e0c61b8acf</Hash>
</Codenesium>*/