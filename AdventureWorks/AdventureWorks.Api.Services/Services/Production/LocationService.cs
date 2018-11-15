using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class LocationService : AbstractLocationService, ILocationService
	{
		public LocationService(
			ILogger<ILocationRepository> logger,
			ILocationRepository locationRepository,
			IApiLocationServerRequestModelValidator locationModelValidator,
			IBOLLocationMapper bolLocationMapper,
			IDALLocationMapper dalLocationMapper)
			: base(logger,
			       locationRepository,
			       locationModelValidator,
			       bolLocationMapper,
			       dalLocationMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>93738b6f24838e4f2b938751a2994325</Hash>
</Codenesium>*/