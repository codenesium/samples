using MediatR;
using Microsoft.Extensions.Logging;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class LocationService : AbstractLocationService, ILocationService
	{
		public LocationService(
			ILogger<ILocationRepository> logger,
			IMediator mediator,
			ILocationRepository locationRepository,
			IApiLocationServerRequestModelValidator locationModelValidator,
			IDALLocationMapper dalLocationMapper,
			IDALTweetMapper dalTweetMapper,
			IDALUserMapper dalUserMapper)
			: base(logger,
			       mediator,
			       locationRepository,
			       locationModelValidator,
			       dalLocationMapper,
			       dalTweetMapper,
			       dalUserMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9f38ebd37fcfa2bedd177c7e61ee84c0</Hash>
</Codenesium>*/