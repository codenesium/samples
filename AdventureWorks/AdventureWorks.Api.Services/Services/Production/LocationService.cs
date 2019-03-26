using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class LocationService : AbstractLocationService, ILocationService
	{
		public LocationService(
			ILogger<ILocationRepository> logger,
			IMediator mediator,
			ILocationRepository locationRepository,
			IApiLocationServerRequestModelValidator locationModelValidator,
			IDALLocationMapper dalLocationMapper)
			: base(logger,
			       mediator,
			       locationRepository,
			       locationModelValidator,
			       dalLocationMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>1daaf55e6592c5f0163eb345bcce7762</Hash>
</Codenesium>*/