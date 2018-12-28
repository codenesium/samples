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
			IBOLVenueMapper bolVenueMapper,
			IDALVenueMapper dalVenueMapper)
			: base(logger,
			       mediator,
			       venueRepository,
			       venueModelValidator,
			       bolVenueMapper,
			       dalVenueMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6b198e9fbc9e0b6d686859a26557032d</Hash>
</Codenesium>*/