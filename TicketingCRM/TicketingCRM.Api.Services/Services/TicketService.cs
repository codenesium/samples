using Microsoft.Extensions.Logging;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class TicketService : AbstractTicketService, ITicketService
	{
		public TicketService(
			ILogger<ITicketRepository> logger,
			ITicketRepository ticketRepository,
			IApiTicketServerRequestModelValidator ticketModelValidator,
			IBOLTicketMapper bolTicketMapper,
			IDALTicketMapper dalTicketMapper)
			: base(logger,
			       ticketRepository,
			       ticketModelValidator,
			       bolTicketMapper,
			       dalTicketMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>bfd0f2bd95a12455d1cc0ca12b16b4cf</Hash>
</Codenesium>*/