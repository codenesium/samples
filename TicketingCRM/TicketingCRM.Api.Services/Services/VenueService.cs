using Microsoft.Extensions.Logging;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class VenueService : AbstractVenueService, IVenueService
	{
		public VenueService(
			ILogger<IVenueRepository> logger,
			IVenueRepository venueRepository,
			IApiVenueServerRequestModelValidator venueModelValidator,
			IBOLVenueMapper bolVenueMapper,
			IDALVenueMapper dalVenueMapper)
			: base(logger,
			       venueRepository,
			       venueModelValidator,
			       bolVenueMapper,
			       dalVenueMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>4f971d8364b86b126658dd78955d3b08</Hash>
</Codenesium>*/