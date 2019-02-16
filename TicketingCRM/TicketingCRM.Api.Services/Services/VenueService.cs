using MediatR;
using Microsoft.Extensions.Logging;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class VenueService : AbstractVenueService, IVenueService
	{
		public VenueService(
			ILogger<IVenueRepository> logger,
			IMediator mediator,
			IVenueRepository venueRepository,
			IApiVenueServerRequestModelValidator venueModelValidator,
			IDALVenueMapper dalVenueMapper)
			: base(logger,
			       mediator,
			       venueRepository,
			       venueModelValidator,
			       dalVenueMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9e5634e97b85079a2aba097c9fe4e28a</Hash>
</Codenesium>*/