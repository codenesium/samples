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
			IBOLLocationMapper bolLocationMapper,
			IDALLocationMapper dalLocationMapper)
			: base(logger,
			       mediator,
			       locationRepository,
			       locationModelValidator,
			       bolLocationMapper,
			       dalLocationMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ff17bfff91067ce2dd624719c4e08c04</Hash>
</Codenesium>*/