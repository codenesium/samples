using Microsoft.Extensions.Logging;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class LocationService : AbstractLocationService, ILocationService
	{
		public LocationService(
			ILogger<ILocationRepository> logger,
			ILocationRepository locationRepository,
			IApiLocationServerRequestModelValidator locationModelValidator,
			IBOLLocationMapper bolLocationMapper,
			IDALLocationMapper dalLocationMapper,
			IBOLTweetMapper bolTweetMapper,
			IDALTweetMapper dalTweetMapper,
			IBOLUserMapper bolUserMapper,
			IDALUserMapper dalUserMapper)
			: base(logger,
			       locationRepository,
			       locationModelValidator,
			       bolLocationMapper,
			       dalLocationMapper,
			       bolTweetMapper,
			       dalTweetMapper,
			       bolUserMapper,
			       dalUserMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>23e65827462f908baa3ca05eaedddbb9</Hash>
</Codenesium>*/