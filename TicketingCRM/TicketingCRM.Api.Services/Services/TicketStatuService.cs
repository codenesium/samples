using Microsoft.Extensions.Logging;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class TicketStatuService : AbstractTicketStatuService, ITicketStatuService
	{
		public TicketStatuService(
			ILogger<ITicketStatuRepository> logger,
			ITicketStatuRepository ticketStatuRepository,
			IApiTicketStatuServerRequestModelValidator ticketStatuModelValidator,
			IBOLTicketStatuMapper bolTicketStatuMapper,
			IDALTicketStatuMapper dalTicketStatuMapper,
			IBOLTicketMapper bolTicketMapper,
			IDALTicketMapper dalTicketMapper)
			: base(logger,
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
    <Hash>94bfda7e1ba0afda36967833b6575928</Hash>
</Codenesium>*/